/* (C) 2024 */
package in.nha.abdm.wrapper.v1.hip.hrp.database.mongo.repositories;

import in.nha.abdm.wrapper.v1.hip.hrp.database.mongo.tables.Patient;
import java.util.List;
import org.springframework.data.mongodb.repository.MongoRepository;
import org.springframework.data.mongodb.repository.Query;
import org.springframework.stereotype.Repository;

@Repository
public interface PatientRepo extends MongoRepository<Patient, String> {
  List<Patient> findAllByAbhaAddress(String abhaAddress);

  default Patient findByAbhaAddress(String abhaAddress) {
    return mergePatients(findAllByAbhaAddress(abhaAddress));
  }

  List<Patient> findAllByPatientReference(String patientReference);

  default Patient findByPatientReference(String patientReference) {
    return mergePatients(findAllByPatientReference(patientReference));
  }

  List<Patient> findByPatientMobile(String patientMobile);

  List<Patient> findAllByAbhaAddressAndHipId(String abhaAddress, String hipId);

  default Patient findByAbhaAddress(String abhaAddress, String hipId) {
    return mergePatients(findAllByAbhaAddressAndHipId(abhaAddress, hipId));
  }

  List<Patient> findAllByPatientReferenceAndHipId(String patientReference, String hipId);

  default Patient findByPatientReference(String patientReference, String hipId) {
    return mergePatients(findAllByPatientReferenceAndHipId(patientReference, hipId));
  }

  default Patient mergePatients(List<Patient> list) {
    if (list == null || list.isEmpty()) return null;
    if (list.size() == 1) return list.get(0);
    Patient merged = list.get(0);
    for (int i = 1; i < list.size(); i++) {
      Patient p = list.get(i);
      if (p.getConsents() != null && !p.getConsents().isEmpty()) {
        if (merged.getConsents() == null) {
          merged.setConsents(new java.util.ArrayList<>());
        }
        for (in.nha.abdm.wrapper.v1.common.models.Consent c : p.getConsents()) {
           boolean exists = merged.getConsents().stream()
               .anyMatch(existing -> existing.getConsentDetail().getConsentId().equals(c.getConsentDetail().getConsentId()));
           if (!exists) merged.getConsents().add(c);
        }
      }
      if (p.getCareContexts() != null && !p.getCareContexts().isEmpty()) {
        if (merged.getCareContexts() == null) {
          merged.setCareContexts(new java.util.ArrayList<>());
        }
        for (in.nha.abdm.wrapper.v1.common.models.CareContext cc : p.getCareContexts()) {
           boolean exists = merged.getCareContexts().stream()
               .anyMatch(existing -> existing.getReferenceNumber().equals(cc.getReferenceNumber()));
           if (!exists) merged.getCareContexts().add(cc);
        }
      }
      if (p.getPatientReference() != null && merged.getPatientReference() == null) {
        merged.setPatientReference(p.getPatientReference());
      }
    }
    return merged;
  }

  @Query("{ 'patientMobile': ?0, 'hipId': ?1 }")
  List<Patient> findByPatientMobile(String patientMobile, String hipId);

  @Query("{ 'hipId': ?0 }")
  List<Patient> findAllByHipId(String hipId);
}
