/* (C) 2024 */
package in.nha.abdm.wrapper.v3.patient;

import in.nha.abdm.wrapper.v1.hip.hrp.database.mongo.tables.Prescription;
import in.nha.abdm.wrapper.v3.common.FHIRService;
import in.nha.abdm.wrapper.v3.common.V3NotificationService;
import in.nha.abdm.wrapper.v3.common.logger.ActivityLogService;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.data.mongodb.core.MongoTemplate;
import org.springframework.web.bind.annotation.*;

import java.io.File;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.UUID;

@RestController
@RequestMapping("/v3/prescriptions")
public class PrescriptionController {
  private final MongoTemplate mongoTemplate;
  private final ActivityLogService logService;
  private final FHIRService fhirService;
  private final V3NotificationService notificationService;

  @Value("${recordsPath:records}")
  private String recordsPath;

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
            
            // --- Save to Shared Records Folder for M3 Real-world Transfer ---
            try {
                File dir = new File(recordsPath);
                if (!dir.exists()) dir.mkdirs();
                
                String filename = (prescription.getCareContextReference() != null ? prescription.getCareContextReference() : "V-" + System.currentTimeMillis()) + ".json";
                Files.write(Paths.get(recordsPath, filename), bundle.getBytes());
                logService.logActivity("STORAGE SUCCESS: Saved record to " + filename);
            } catch (Exception e) {
                logService.logActivity("STORAGE ERROR: Failed to save record - " + e.getMessage());
            }

            // M3 Flow: Push the data notification to the Gateway.
            notificationService.notifyGateway(prescription);
        }, error -> {
            logService.logActivity("FHIR ERROR: Failed for " + prescription.getAbhaAddress() + " - " + error.getMessage());
        });
    
    return "Prescription Saved & FHIR Push Initiated Successfully!";
  }
}
