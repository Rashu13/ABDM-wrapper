/* (C) 2024 */
package in.nha.abdm.wrapper.v3.hiu;

import in.nha.abdm.wrapper.v1.common.exceptions.IllegalDataStateException;
import in.nha.abdm.wrapper.v1.hiu.hrp.consent.requests.InitConsentRequest;
import in.nha.abdm.wrapper.v3.common.logger.ActivityLogService;
import in.nha.abdm.wrapper.v3.common.models.FacadeV3Response;
import in.nha.abdm.wrapper.v3.hiu.hrp.consent.HIUConsentV3Service;
import org.springframework.web.bind.annotation.*;
import java.util.Collections;

@RestController
@RequestMapping("/v3/hiu")
public class HiuV3Controller {
  private final ActivityLogService logService;
  private final HIUConsentV3Service hiuConsentV3Service;

  public HiuV3Controller(ActivityLogService logService, HIUConsentV3Service hiuConsentV3Service) {
    this.logService = logService;
    this.hiuConsentV3Service = hiuConsentV3Service;
  }

  @PostMapping("/consent/request")
  public FacadeV3Response initiateConsentRequest(@RequestBody InitConsentRequest request) throws IllegalDataStateException {
    logService.logActivity("HIU-INITIATED: New consent request posted to Gateway.");
    return hiuConsentV3Service.initiateConsentRequest(request);
  }

  @GetMapping("/health-information/fetch/{consentId}")
  public Object fetchPatientRecords(@PathVariable String consentId) {
    logService.logActivity("HIU-INITIATED: Fetching records for ConsentId: " + consentId);
    // Mocking a successful data fetch for testing
    return Collections.singletonMap("data", "Sample Encrypted FHIR Bundle Data From Apollo/AIIMS");
  }
}
