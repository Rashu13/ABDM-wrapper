/* (C) 2024 */
package in.nha.abdm.wrapper.v3.patient;

import in.nha.abdm.wrapper.v1.common.GatewayConstants;
import in.nha.abdm.wrapper.v1.common.responses.ErrorResponse;
import in.nha.abdm.wrapper.v1.common.responses.ErrorV3Response;
import in.nha.abdm.wrapper.v1.hip.hrp.database.mongo.tables.Patient;
import in.nha.abdm.wrapper.v3.common.constants.FacadeURL;
import in.nha.abdm.wrapper.v3.common.constants.WrapperConstants;
import in.nha.abdm.wrapper.v3.common.models.FacadeV3Response;
import in.nha.abdm.wrapper.v3.database.mongo.services.PatientV3Service;
import jakarta.validation.constraints.NotNull;
import java.util.Collections;
import java.util.Objects;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.validation.annotation.Validated;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping(path = "/v3")
@Validated
public class PatientV3Controller {
  private final PatientV3Service patientService;
  private final in.nha.abdm.wrapper.v3.common.logger.ActivityLogService activityService;

  public PatientV3Controller(PatientV3Service patientService, in.nha.abdm.wrapper.v3.common.logger.ActivityLogService activityService) {
    this.patientService = patientService;
    this.activityService = activityService;
  }

  /**
   * This controller is used to fetch all the details of the patient which includes
   * careContext+consent
   *
   * @param patientId abhaAddress
   * @param hipId facilityId
   * @return patient
   */
  @GetMapping("/patient" + FacadeURL.PATIENT_ID_PATH)
  public ResponseEntity<Object> getPatientDetails(
      @PathVariable("patientId") String patientId,
      @RequestParam(WrapperConstants.HIP_ID) @NotNull(message = "hipId is mandatory") String hipId) {
    activityService.logActivity("GATEWAY-HIT: Searching patient: " + patientId);
    Patient patient = patientService.getPatient(patientId, hipId);
    if (Objects.isNull(patient)) {
      FacadeV3Response facadeV3Response =
          FacadeV3Response.builder()
              .httpStatusCode(HttpStatus.BAD_REQUEST)
              .message("No Patient found")
              .errors(
                  Collections.singletonList(
                      ErrorV3Response.builder()
                          .error(
                              ErrorResponse.builder()
                                  .code(GatewayConstants.ERROR_CODE)
                                  .message(
                                      String.format(
                                          "%s not found in %s facility", patientId, hipId))
                                  .build())
                          .build()))
              .build();
      return new ResponseEntity<>(facadeV3Response, HttpStatus.BAD_REQUEST);
    }
    return new ResponseEntity<>(patient, HttpStatus.OK);
  }

  @GetMapping("/patients")
  public ResponseEntity<java.util.List<in.nha.abdm.wrapper.v1.hip.hrp.database.mongo.tables.Patient>> getAllPatients(
      @RequestParam(WrapperConstants.HIP_ID) @NotNull(message = "hipId is mandatory") String hipId) {
    java.util.List<in.nha.abdm.wrapper.v1.hip.hrp.database.mongo.tables.Patient> patients = patientService.getAllPatients(hipId);
    return new ResponseEntity<>(patients, HttpStatus.OK);
  }
}
