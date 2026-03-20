/* (C) 2024 */
package in.nha.abdm.wrapper.v3.hiu;

import in.nha.abdm.wrapper.v3.common.logger.ActivityLogService;
import org.springframework.web.bind.annotation.*;
import java.util.Collections;

@RestController
@RequestMapping("/v3/hiu")
public class HiuV3Controller {
  private final ActivityLogService logService;

  public HiuV3Controller(ActivityLogService logService) {
    this.logService = logService;
  }

  @PostMapping("/consent/request")
  public String initiateConsentRequest(@RequestBody Object request) {
    logService.logActivity("HIU-INITIATED: New consent request posted to Gateway.");
    // This will ideally call the Wrapper's internal /consent/init service
    return "Consent Request Initialized Success! (RequestId: HIU-" + java.util.UUID.randomUUID() + ")";
  }

  @GetMapping("/health-information/fetch/{consentId}")
  public Object fetchPatientRecords(@PathVariable String consentId) {
    logService.logActivity("HIU-INITIATED: Fetching records for ConsentId: " + consentId);
    // Mocking a successful data fetch for testing
    return Collections.singletonMap("data", "Sample Encrypted FHIR Bundle Data From Apollo/AIIMS");
  }
}
