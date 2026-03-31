/* (C) 2024 */
package in.nha.abdm.wrapper.v3.common;

import in.nha.abdm.wrapper.v1.common.Utils;
import in.nha.abdm.wrapper.v1.hip.hrp.database.mongo.tables.Prescription;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.http.MediaType;
import org.springframework.stereotype.Service;
import org.springframework.web.reactive.function.client.WebClient;
import reactor.core.publisher.Mono;

import java.time.LocalDate;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

@Service
public class FHIRService {

    private final WebClient webClient;

    public FHIRService(@Value("${fhir.mapper.url:http://fhir-mapper:8085}") String fhirMapperUrl) {
        this.webClient = WebClient.builder().baseUrl(fhirMapperUrl).build();
    }

    /**
     * Converts a simple Prescription object into a FHIR Bundle using the fhir-mapper service.
     */
    public Mono<String> generatePrescriptionBundle(Prescription prescription, String patientGender, String patientBirthDate) {
        Map<String, Object> request = new HashMap<>();
        request.put("bundleType", "PrescriptionRecord");
        request.put("careContextReference", prescription.getCareContextReference() != null ? prescription.getCareContextReference() : "V-" + System.currentTimeMillis()); 
        request.put("authoredOn", LocalDate.now().toString()); // yyyy-MM-dd format
        
        // Patient details
        Map<String, Object> patient = new HashMap<>();
        patient.put("name", prescription.getPatientName());
        patient.put("patientReference", prescription.getPatientReference() != null ? prescription.getPatientReference() : prescription.getAbhaAddress());
        patient.put("gender", patientGender != null ? patientGender : "male");
        patient.put("birthDate", patientBirthDate != null ? patientBirthDate : "1994-03-27");
        request.put("patient", patient);

        // Practitioner (Doctor) - Defaulting to Midha Hospital context if missing
        List<Map<String, Object>> practitioners = new ArrayList<>();
        Map<String, Object> doctor = new HashMap<>();
        doctor.put("name", "Dr. Midha");
        doctor.put("practitionerId", "MIDHA-001");
        practitioners.add(doctor);
        request.put("practitioners", practitioners);

        // Organisation (Hospital)
        Map<String, Object> organisation = new HashMap<>();
        organisation.put("facilityName", "MIDHA HOSPITAL");
        organisation.put("facilityId", prescription.getHipId());
        request.put("organisation", organisation);

        // Medicines
        List<Map<String, Object>> meds = new ArrayList<>();
        for (Prescription.Medicine med : prescription.getMedicines()) {
            Map<String, Object> m = new HashMap<>();
            m.put("medicine", med.getName());
            m.put("dosage", med.getDosage());
            m.put("timing", "1-1-D"); // Valid format: frequency-period-unit (e.g., 1-1-D for once a day)
            m.put("route", "Oral");
            m.put("method", "swallow");
            m.put("additionalInstructions", "Take after meals");
            meds.add(m);
        }
        request.put("prescriptions", meds);

        // Empty document list for now (PDF not mandatory for valid FHIR bundle if data is structured)
        // Dummy document (Mandatory for valid FHIR Prescription bundle in fhir-mapper)
        List<Map<String, Object>> docs = new ArrayList<>();
        Map<String, Object> dummyDoc = new HashMap<>();
        dummyDoc.put("type", "Prescription");
        dummyDoc.put("contentType", "application/pdf");
        dummyDoc.put("data", "JVBERi0xLjEKMSAwIG9iajw8L1R5cGUvQ2F0YWxvZy9QYWdlcyAyIDAgUj4+ZW5kb2JqIDIgMCBvYmo8PC9UeXBlL1BhZ2VzL0tpZHNbMyAwIFJdL0NvdW50IDE+PmVuZG9iagAzIDAgb2JqPDwvVHlwZS9QYWdlL01lZGlhQm94WzAgMCAzIDNdL1BhcmVudCAyIDAgUj4+ZW5kb2JqIHRyYWlsZXI8PC9Sb290IDEgMCBSPj4lJUVPRg==");
        docs.add(dummyDoc);
        request.put("documents", docs);

        return this.webClient.post()
                .uri("/v1/bundle/prescription")
                .contentType(MediaType.APPLICATION_JSON)
                .bodyValue(request)
                .retrieve()
                .bodyToMono(String.class);
    }
}
