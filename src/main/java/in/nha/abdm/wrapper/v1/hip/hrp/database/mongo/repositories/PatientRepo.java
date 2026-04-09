/* (C) 2024 */
package in.nha.abdm.wrapper.v1.hip.hrp.database.mongo.repositories;

import in.nha.abdm.wrapper.v1.hip.hrp.database.mongo.tables.Patient;
import java.util.List;
import org.springframework.data.mongodb.repository.MongoRepository;
import org.springframework.data.mongodb.repository.Query;
import org.springframework.stereotype.Repository;

@Repository
public interface PatientRepo extends MongoRepository<Patient, String> {
  Patient findFirstByAbhaAddress(String abhaAddress);

  default Patient findByAbhaAddress(String abhaAddress) {
    return findFirstByAbhaAddress(abhaAddress);
  }

  Patient findFirstByPatientReference(String patientReference);

  default Patient findByPatientReference(String patientReference) {
    return findFirstByPatientReference(patientReference);
  }

  List<Patient> findByPatientMobile(String patientMobile);

  Patient findFirstByAbhaAddressAndHipId(String abhaAddress, String hipId);

  default Patient findByAbhaAddress(String abhaAddress, String hipId) {
    return findFirstByAbhaAddressAndHipId(abhaAddress, hipId);
  }

  Patient findFirstByPatientReferenceAndHipId(String patientReference, String hipId);

  default Patient findByPatientReference(String patientReference, String hipId) {
    return findFirstByPatientReferenceAndHipId(patientReference, hipId);
  }

  @Query("{ 'patientMobile': ?0, 'hipId': ?1 }")
  List<Patient> findByPatientMobile(String patientMobile, String hipId);

  @Query("{ 'hipId': ?0 }")
  List<Patient> findAllByHipId(String hipId);
}
