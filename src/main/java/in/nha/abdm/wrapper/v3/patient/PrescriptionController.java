/* (C) 2024 */
package in.nha.abdm.wrapper.v3.patient;

import in.nha.abdm.wrapper.v1.hip.hrp.database.mongo.tables.Prescription;
import in.nha.abdm.wrapper.v3.common.FHIRService;
import in.nha.abdm.wrapper.v3.common.V3NotificationService;
import in.nha.abdm.wrapper.v3.common.logger.ActivityLogService;
import org.springframework.data.mongodb.core.MongoTemplate;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/v3/prescriptions")
public class PrescriptionController {
  private final MongoTemplate mongoTemplate;
  private final ActivityLogService logService;
  private final FHIRService fhirService;
  private final V3NotificationService notificationService;

  public PrescriptionController(MongoTemplate mongoTemplate, ActivityLogService logService, FHIRService fhirService, V3NotificationService notificationService) {
    this.mongoTemplate = mongoTemplate;
    this.logService = logService;
    this.fhirService = fhirService;
    this.notificationService = notificationService;
  }

  @PostMapping
  public String savePrescription(@RequestBody Prescription prescription) {
    logService.logActivity("HIP-INITIATED: Saving prescription for " + prescription.getAbhaAddress());
    mongoTemplate.save(prescription);
    
    // Trigger FHIR generation (Asynchronously)
    fhirService.generatePrescriptionBundle(prescription, prescription.getGender(), prescription.getBirthDate())
        .subscribe(bundle -> {
            logService.logActivity("FHIR SUCCESS: Generated bundle for " + prescription.getAbhaAddress());
            // M3 Flow: Push the data notification to the Gateway.
            notificationService.notifyGateway(prescription);
        }, error -> {
            logService.logActivity("FHIR ERROR: Failed for " + prescription.getAbhaAddress() + " - " + error.getMessage());
        });
    
    return "Prescription Saved & FHIR Push Initiated Successfully!";
  }
}
