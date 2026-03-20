/* (C) 2024 */
package in.nha.abdm.wrapper.v3.database.mongo.services;

import in.nha.abdm.wrapper.v1.common.Utils;
import in.nha.abdm.wrapper.v1.hip.hrp.database.mongo.tables.helpers.FieldIdentifiers;
import in.nha.abdm.wrapper.v3.database.mongo.repositories.LinkTokenRepo;
import in.nha.abdm.wrapper.v3.database.mongo.tables.LinkToken;
import java.time.LocalDateTime;
import java.util.Objects;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.mongodb.core.MongoTemplate;
import org.springframework.data.mongodb.core.query.Criteria;
import org.springframework.data.mongodb.core.query.Query;
import org.springframework.data.mongodb.core.query.Update;
import org.springframework.stereotype.Service;

@Service
public class LinkTokenService {
  private static final Logger log = LoggerFactory.getLogger(LinkTokenService.class);
  @Autowired LinkTokenRepo linkTokenRepo;
  @Autowired MongoTemplate mongoTemplate;

  /**
   * Checking the expiry of the LinkToken, if expired or not available returns null
   *
   * @param abhaAddress
   * @param entity
   * @return
   */
  public String getLinkToken(String abhaAddress, String entity) {
    Query query =
        new Query(
            Criteria.where(FieldIdentifiers.ABHA_ADDRESS)
                .is(abhaAddress)
                .and(FieldIdentifiers.HIP_ID)
                .is(entity));
    LinkToken linkToken = mongoTemplate.findOne(query, LinkToken.class);
    if (linkToken != null
        && linkToken.getLinkToken() != null
        && !Utils.checkExpiry(linkToken.getExpiry())) {
      return linkToken.getLinkToken();
    }
    return null;
  }

  /**
   * Check if a request for LinkToken is already in progress
   *
   * @param abhaAddress
   * @param entity
   * @return true if requestId exists but linkToken is null
   */
  public boolean isRequestPending(String abhaAddress, String entity) {
    Query query =
        new Query(
            Criteria.where(FieldIdentifiers.ABHA_ADDRESS)
                .is(abhaAddress)
                .and(FieldIdentifiers.HIP_ID)
                .is(entity));
    LinkToken linkToken = mongoTemplate.findOne(query, LinkToken.class);
    if (linkToken == null) {
      return false;
    }
    // Check for 3-attempt limit in 24 hours
    if (linkToken.getLastRequestDate() != null) {
      LocalDateTime lastRequest = LocalDateTime.parse(linkToken.getLastRequestDate());
      if (lastRequest.isAfter(LocalDateTime.now().minusHours(24))) {
        if (linkToken.getRequestCount() >= 3 && (linkToken.getLinkToken() == null || Utils.checkExpiry(linkToken.getExpiry()))) {
          return true; // Treat as pending/blocked to prevent further calls
        }
      } else {
        // More than 24 hours have passed, reset count
        Update update = new Update().set("requestCount", 0);
        mongoTemplate.updateFirst(query, update, LinkToken.class);
      }
    }

    return linkToken.getLinkTokenRequestId() != null
        && (linkToken.getLinkToken() == null || Utils.checkExpiry(linkToken.getExpiry()));
  }

  /**
   * Saving of LinkToken with respective of ABHA Address
   *
   * @param abhaAddress
   * @param linkToken
   * @param entity
   */
  public void saveLinkToken(String abhaAddress, String linkToken, String entity) {
    log.info("Saving linkToken of " + abhaAddress + " " + entity);
    Query query =
        new Query(
            Criteria.where(FieldIdentifiers.ABHA_ADDRESS)
                .is(abhaAddress)
                .and(FieldIdentifiers.HIP_ID)
                .is(entity));
    LinkToken existingToken = mongoTemplate.findOne(query, LinkToken.class);
    if (Objects.nonNull(existingToken)) {
      Update update = new Update();
      update.set(FieldIdentifiers.LINK_TOKEN, linkToken);
      update.set(FieldIdentifiers.EXPIRY, Utils.setLinkTokenExpiry());
      mongoTemplate.upsert(query, update, LinkToken.class);
    } else {
      LinkToken newToken = new LinkToken();
      newToken.setAbhaAddress(abhaAddress);
      newToken.setLinkToken(linkToken);
      newToken.setExpiry(Utils.setLinkTokenExpiry());
      newToken.setHipId(entity);
      mongoTemplate.insert(newToken);
    }
  }

  /**
   * Saving the LinkToken while initiation of careContext linking.
   *
   * @param abhaAddress
   * @param entity
   * @param linkTokenRequestId
   */
  public void saveLinkTokenRequestId(String abhaAddress, String entity, String linkTokenRequestId) {
    Query query =
        new Query(
            Criteria.where(FieldIdentifiers.ABHA_ADDRESS)
                .is(abhaAddress)
                .and(FieldIdentifiers.HIP_ID)
                .is(entity));
    LinkToken existingToken = mongoTemplate.findOne(query, LinkToken.class);

    if (Objects.nonNull(existingToken)) {
      Update update = new Update();
      update.set(FieldIdentifiers.LINK_TOKEN_REQUEST_ID, linkTokenRequestId);
      update.set("lastRequestDate", LocalDateTime.now().toString());
      update.inc("requestCount", 1);
      mongoTemplate.upsert(query, update, LinkToken.class);
    } else {
      LinkToken newToken = new LinkToken();
      newToken.setAbhaAddress(abhaAddress);
      newToken.setHipId(entity);
      newToken.setLinkTokenRequestId(linkTokenRequestId);
      newToken.setLastRequestDate(LocalDateTime.now().toString());
      newToken.setRequestCount(1);
      mongoTemplate.save(newToken);
    }
  }
}
