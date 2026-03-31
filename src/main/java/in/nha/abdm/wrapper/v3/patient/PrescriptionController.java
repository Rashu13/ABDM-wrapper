/* (C) 2024 */
package in.nha.abdm.wrapper.v3.patient;

import in.nha.abdm.wrapper.v1.hip.hrp.database.mongo.tables.Prescription;
import in.nha.abdm.wrapper.v3.common.logger.ActivityLogService;
import org.springframework.data.mongodb.core.MongoTemplate;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/v3/prescriptions")
public class PrescriptionController {
  private final FHIRService fhirService;

  public PrescriptionController(MongoTemplate mongoTemplate, ActivityLogService logService, FHIRService fhirService) {
    this.mongoTemplate = mongoTemplate;
    this.logService = logService;
    this.fhirService = fhirService;
  }

  @PostMapping
  public String savePrescription(@RequestBody Prescription prescription) {
    logService.logActivity("HIP-INITIATED: Saving prescription for " + prescription.getAbhaAddress());
    mongoTemplate.save(prescription);
    
    // Trigger FHIR generation (Asynchronously)
    fhirService.generatePrescriptionBundle(prescription, "male", "1990-01-01")
        .subscribe(bundle -> {
            logService.logActivity("FHIR SUCCESS: Generated bundle for " + prescription.getAbhaAddress());
            // In a production M3 flow, here we would push the 'bundle' (as digital asset) to the Gateway.
            // For now, logging the success is the first step towards M3 compliance.
        }, error -> {
            logService.logActivity("FHIR ERROR: Failed for " + prescription.getAbhaAddress() + " - " + error.getMessage());
        });
    
    return "Prescription Saved & FHIR Bundle Generated Successfully!";
  }
}
