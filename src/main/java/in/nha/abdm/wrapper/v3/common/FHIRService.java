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
        request.put("careContextReference", "V-" + System.currentTimeMillis()); 
        request.put("authoredOn", LocalDate.now().toString()); // yyyy-MM-dd format
        
        // Patient details
        Map<String, Object> patient = new HashMap<>();
        patient.put("name", prescription.getPatientName());
        patient.put("patientReference", prescription.getAbhaAddress());
        patient.put("gender", patientGender != null ? patientGender : "male");
        patient.put("birthDate", patientBirthDate != null ? patientBirthDate : "1990-01-01");
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
            m.put("timing", "1-0-1"); // Default if not provided
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
        dummyDoc.put("data", "JVBERi0xLjQKJSDi4u7yCjEgMCBvYmoKPDwNL0xlbmd0aCAyNgoNL0ZpbHRlciAvRmxhdGVEZWNvZGUKPj4Nc3RyZWFtCnicS0vMSeUCAA0SAnUKZW5kc3RyZWFtDWVuZG9iag0yIDAgb2JqCjw8DS9UeXBlIC9QYWdlcw0vQ291bnQgMQ0vS2lkcyBbIDMgMCBSIF0NPj4NZW5kb2JqDTMgMCBvYmoKPDwNL1R5cGUgL1BhZ2UNL1BhcmVudCAyIDAgUg0vUmVzb3VyY2VzIDw8DS9Gb250IDw8DS9GMSA0IDAgUg0++IDUgMCBSID4+DT4+DWVuZG9iag02IDAgb2JqCjw8DS9UeXBlIC9DYXRhbG9nDS9QYWdlcyAyIDAgUg0+Pg1lbmRvYmoNNyAwIG9iago8PA0vUHJvZHVjZXIgKGRvY3VtZW50cy5jb20pDS9DcmVhdGlvbkRhdGUgKEQ6MjAyNDA0MTIxMTU1MzcpDT4+DWVuZG9iag10cmFpbGVyCjw8DS9TaXplIDgNL1Jvb3QgNiAwIFINL0luZm8gNyAwIFINPj4Nc3RhcnR4cmVmDTY0MA0lJUVPRg=="); // Small valid PDF base64
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
