/* (C) 2024 */
package in.nha.abdm.wrapper.v3.common.logger;

import java.util.List;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("/v3/activities")
public class ActivityLogController {
  private final ActivityLogService logService;

  public ActivityLogController(ActivityLogService logService) {
    this.logService = logService;
  }

  @GetMapping
  public List<String> getActivities() {
    return logService.getRecentActivities();
  }
}
