/* (C) 2024 */
package in.nha.abdm.wrapper.v3.common;

import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.stereotype.Service;
import org.springframework.web.reactive.function.client.WebClient;
import org.springframework.web.util.UriComponentsBuilder;

@Service
public class SmsService {

  private static final Logger log = LogManager.getLogger(SmsService.class);

  @Value("${sms.api.url}")
  private String smsApiUrl;

  @Value("${sms.api.username}")
  private String username;

  @Value("${sms.api.key}")
  private String apiKey;

  @Value("${sms.api.sender}")
  private String sender;

  @Value("${sms.api.templateId}")
  private String templateId;

  @Value("${sms.api.messageTemplate}")
  private String messageTemplate;

  private final WebClient webClient;

  public SmsService() {
    this.webClient = WebClient.builder().build();
  }

  public void sendOtp(String mobile, String otp) {
    try {
      String message = messageTemplate.replace("{#var#}", otp);

      String url =
          UriComponentsBuilder.fromHttpUrl(smsApiUrl)
              .queryParam("username", username)
              .queryParam("apikey", apiKey)
              .queryParam("apirequest", "Text")
              .queryParam("sender", sender)
              .queryParam("mobile", mobile)
              .queryParam("message", message)
              .queryParam("route", "DND")
              .queryParam("TemplateID", templateId)
              .queryParam("format", "JSON")
              .build()
              .toUriString();

      log.info("Sending SMS to {}: {}", mobile, message);

      webClient
          .get()
          .uri(url)
          .retrieve()
          .bodyToMono(String.class)
          .doOnSuccess(
              response -> log.info("SMS sent successfully to {}. Response: {}", mobile, response))
          .doOnError(error -> log.error("Failed to send SMS to {}: {}", mobile, error.getMessage()))
          .subscribe();

    } catch (Exception e) {
      log.error("Error constructing SMS request: {}", e.getMessage());
    }
  }
}
