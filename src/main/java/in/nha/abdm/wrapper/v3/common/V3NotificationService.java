/* (C) 2024 */
package in.nha.abdm.wrapper.v3.common;

import in.nha.abdm.wrapper.v1.common.GatewayConstants;
import in.nha.abdm.wrapper.v1.common.Utils;
import in.nha.abdm.wrapper.v1.hip.hrp.database.mongo.tables.Prescription;
import in.nha.abdm.wrapper.v3.common.logger.ActivityLogService;
import in.nha.abdm.wrapper.v3.common.models.V3NotifyRequest;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.http.HttpHeaders;
import org.springframework.stereotype.Service;

import java.util.Collections;
import java.util.UUID;

@Service
public class V3NotificationService {

    private final RequestV3Manager requestV3Manager;
    private final ActivityLogService activityLogService;

    @Value("${linkContextNotifyPath}")
    private String linkContextNotifyPath;

    @Value("${clientId}")
    private String hipId;

    public V3NotificationService(RequestV3Manager requestV3Manager, ActivityLogService activityLogService) {
        this.requestV3Manager = requestV3Manager;
        this.activityLogService = activityLogService;
    }

    /**
     * Notifies the ABDM Gateway that a new health record (like a prescription)
     * is available for a patient.
     */
    public void notifyGateway(Prescription prescription) {
        V3NotifyRequest request = V3NotifyRequest.builder()
                .requestId(UUID.randomUUID().toString())
                .timestamp(Utils.getCurrentTimeStamp())
                .notification(V3NotifyRequest.V3Notification.builder()
                        .careContext(V3NotifyRequest.V3CareContext.builder()
                                .careContextReference("V-" + System.currentTimeMillis()) 
                                .patientReference("P-" + prescription.getAbhaAddress())
                                .build())
                        .hiTypes(Collections.singletonList("Prescription"))
                        .patient(V3NotifyRequest.V3Patient.builder()
                                .id(prescription.getAbhaAddress())
                                .build())
                        .date(Utils.getCurrentTimeStamp())
                        .hip(V3NotifyRequest.V3HIP.builder()
                                .id(hipId)
                                .build())
                        .build())
                .build();

        try {
            String requestId = UUID.randomUUID().toString();
            HttpHeaders headers = Utils.getCustomHeaders(GatewayConstants.X_HIP_ID, hipId, requestId);
            
            activityLogService.logActivity("GATEWAY NOTIFY: Initiating for " + prescription.getAbhaAddress());
            requestV3Manager.fetchResponseFromGateway(linkContextNotifyPath, request, headers);
            activityLogService.logActivity("GATEWAY NOTIFY: Successfully notified for " + prescription.getAbhaAddress());
        } catch (Exception e) {
            activityLogService.logActivity("GATEWAY NOTIFY ERROR: Failed for " + prescription.getAbhaAddress() + " - " + e.getMessage());
        }
    }
}
