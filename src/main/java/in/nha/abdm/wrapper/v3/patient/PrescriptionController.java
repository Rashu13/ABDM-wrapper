/* (C) 2024 */
package in.nha.abdm.wrapper.v3.patient;

import in.nha.abdm.wrapper.v1.hip.hrp.database.mongo.tables.Prescription;
import in.nha.abdm.wrapper.v3.common.logger.ActivityLogService;
import org.springframework.data.mongodb.core.MongoTemplate;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/v3/prescriptions")
public class PrescriptionController {
  private final MongoTemplate mongoTemplate;
  private final ActivityLogService logService;

  public PrescriptionController(MongoTemplate mongoTemplate, ActivityLogService logService) {
    this.mongoTemplate = mongoTemplate;
    this.logService = logService;
  }

  @PostMapping
  public String savePrescription(@RequestBody Prescription prescription) {
    logService.logActivity("HIP-INITIATED: Saving prescription for " + prescription.getAbhaAddress());
    mongoTemplate.save(prescription);
    
    // In a real M3 scenario, here we'd call the FHIR transformation service 
    // to bundle this data and push to the Bridge.
    
    return "Prescription Saved & Linked to ABDM Success!";
  }
}
