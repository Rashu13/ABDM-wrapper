/* (C) 2024 */
package in.nha.abdm.wrapper.v3.common.models;

import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;
import java.util.List;

@Data
@Builder
@NoArgsConstructor
@AllArgsConstructor
public class V3NotifyRequest {
    private String requestId;
    private String timestamp;
    private V3Notification notification;

    @Data
    @Builder
    @NoArgsConstructor
    @AllArgsConstructor
    public static class V3Notification {
        private V3CareContext careContext;
        private List<String> hiTypes;
        private V3Patient patient;
        private String date;
        private V3HIP hip;
    }

    @Data
    @Builder
    @NoArgsConstructor
    @AllArgsConstructor
    public static class V3CareContext {
        private String careContextReference;
        private String patientReference;
    }

    @Data
    @Builder
    @NoArgsConstructor
    @AllArgsConstructor
    public static class V3Patient {
        private String id;
    }

    @Data
    @Builder
    @NoArgsConstructor
    @AllArgsConstructor
    public static class V3HIP {
        private String id;
    }
}
