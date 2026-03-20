/* (C) 2024 */
package in.nha.abdm.wrapper.v3.common.logger;

import java.util.LinkedList;
import java.util.List;
import org.springframework.stereotype.Service;

@Service
public class ActivityLogService {
  private final LinkedList<String> activityLogs = new LinkedList<>();
  private static final int MAX_LOGS = 50;

  public synchronized void logActivity(String log) {
    if (activityLogs.size() >= MAX_LOGS) {
      activityLogs.removeLast();
    }
    activityLogs.addFirst(java.time.LocalDateTime.now() + " - " + log);
  }

  public synchronized List<String> getRecentActivities() {
    return new LinkedList<>(activityLogs);
  }
}
