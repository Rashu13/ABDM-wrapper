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
import java.util.Collections;
import java.util.Map;

@RestController
@RequestMapping({"/v3/health-records", "/v3/prescriptions"})
public class HealthRecordV3Controller {
  private final MongoTemplate mongoTemplate;
  private final ActivityLogService logService;
  private final FHIRService fhirService;
  private final V3NotificationService notificationService;

  @Value("${recordsPath:records}")
  private String recordsPath;

  public HealthRecordV3Controller(MongoTemplate mongoTemplate, ActivityLogService logService, FHIRService fhirService, V3NotificationService notificationService) {
    this.mongoTemplate = mongoTemplate;
    this.logService = logService;
    this.fhirService = fhirService;
    this.notificationService = notificationService;
  }

  /**
   * Generic endpoint to save health records (Prescription, DiagnosticReport, etc.)
   */
  @PostMapping
  public String saveHealthRecord(@RequestBody Prescription record) {
    String hiType = record.getHiType() != null ? record.getHiType() : "Prescription";
    logService.logActivity("HIP-INITIATED: Saving " + hiType + " for " + record.getAbhaAddress());
    
    // Save to Mongo
    mongoTemplate.save(record);
    
    // Trigger FHIR generation (Asynchronously)
    fhirService.generateFHIRBundle(record, hiType, record.getGender(), record.getBirthDate())
        .subscribe(bundle -> {
            logService.logActivity("FHIR SUCCESS: Generated " + hiType + " bundle for " + record.getAbhaAddress());
            
            // --- Save to Shared Records Folder for M3 Real-world Transfer ---
            try {
                String filename = (record.getCareContextReference() != null ? record.getCareContextReference() : "V-" + System.currentTimeMillis()) + ".json";
                java.nio.file.Path filePath = java.nio.file.Paths.get(recordsPath, filename);
                
                // Ensure parent directories (e.g. Prescription/) exist
                java.nio.file.Files.createDirectories(filePath.getParent());
                
                java.nio.file.Files.write(filePath, bundle.getBytes());
                logService.logActivity("STORAGE SUCCESS: Saved record to " + filename);
            } catch (Exception e) {
                logService.logActivity("STORAGE ERROR: Failed to save record - " + e.getMessage());
            }

            // M3 Flow: Push the data notification to the Gateway.
            notificationService.notifyGateway(record);
        }, error -> {
            logService.logActivity("FHIR ERROR: Failed for " + record.getAbhaAddress() + " (" + hiType + ") - " + error.getMessage());
        });
    
    return hiType + " Saved & FHIR Push Initiated Successfully!";
  }

  /**
   * Endpoint for WinForms UI to fetch the raw FHIR bundle JSON for a specific Care Context.
   */
  @GetMapping("/{careContextReference}")
  public Object fetchRecord(@PathVariable String careContextReference) {
    try {
        String filename = careContextReference + ".json";
        byte[] content = Files.readAllBytes(Paths.get(recordsPath, filename));
        logService.logActivity("UI-FETCH: Record retrieved for " + careContextReference);
        return new String(content);
    } catch (Exception e) {
        logService.logActivity("UI-FETCH ERROR: Could not find record for " + careContextReference);
        return Collections.singletonMap("error", "Record not found locally: " + e.getMessage());
    }
  }
}
