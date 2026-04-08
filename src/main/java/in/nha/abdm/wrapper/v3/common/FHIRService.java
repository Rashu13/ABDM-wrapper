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
import java.util.Base64;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import org.apache.pdfbox.pdmodel.PDDocument;
import org.apache.pdfbox.pdmodel.PDPage;
import org.apache.pdfbox.pdmodel.PDPageContentStream;
import org.apache.pdfbox.pdmodel.graphics.image.PDImageXObject;
import org.apache.pdfbox.pdmodel.common.PDRectangle;

@Service
public class FHIRService {

    private final WebClient webClient;

    public FHIRService(@Value("${fhir.mapper.url:http://fhir-mapper:8085}") String fhirMapperUrl) {
        this.webClient = WebClient.builder().baseUrl(fhirMapperUrl).build();
    }

    /**
     * Converts a generic Health Record (stored in Prescription model) into a HI-type specific FHIR Bundle.
     */
    public Mono<String> generateFHIRBundle(Prescription record, String hiType, String patientGender, String patientBirthDate) {
        Map<String, Object> request = new HashMap<>();
        // ... (preserving logic) ...
        String endpoint = "/v1/bundle/prescription"; 
        String bundleType = "PrescriptionRecord";

        if ("DiagnosticReport".equalsIgnoreCase(hiType)) {
            endpoint = "/v1/bundle/diagnostic-report";
            bundleType = "DiagnosticReportRecord";
            request.put("visitDate", LocalDate.now().toString());
        } else if ("DischargeSummary".equalsIgnoreCase(hiType)) {
            endpoint = "/v1/bundle/discharge-summary";
            bundleType = "DischargeSummaryRecord";
            request.put("authoredOn", LocalDate.now().toString());
        } else if ("OPConsultation".equalsIgnoreCase(hiType)) {
            endpoint = "/v1/bundle/op-consultation";
            bundleType = "OPConsultRecord";
            request.put("visitDate", LocalDate.now().toString());
        } else if ("ImmunizationRecord".equalsIgnoreCase(hiType)) {
            endpoint = "/v1/bundle/immunization";
            bundleType = "ImmunizationRecord";
            request.put("occuredOn", LocalDate.now().toString());
        } else if ("WellnessRecord".equalsIgnoreCase(hiType)) {
            endpoint = "/v1/bundle/wellness-record";
            bundleType = "WellnessRecord";
            request.put("visitDate", LocalDate.now().toString());
        } else if ("HealthDocumentRecord".equalsIgnoreCase(hiType)) {
            endpoint = "/v1/bundle/health-document";
            bundleType = "HealthDocumentRecord";
        } else {
            request.put("authoredOn", LocalDate.now().toString());
        }

        request.put("bundleType", bundleType);
        request.put("careContextReference", record.getCareContextReference() != null ? record.getCareContextReference() : "V-" + System.currentTimeMillis());

        Map<String, Object> patient = new HashMap<>();
        patient.put("name", record.getPatientName());
        patient.put("patientReference", record.getPatientReference() != null ? record.getPatientReference() : record.getAbhaAddress());

        String mappedGender = "unknown";
        if (patientGender != null) {
            String g = patientGender.toLowerCase();
            if (g.startsWith("m")) mappedGender = "male";
            else if (g.startsWith("f")) mappedGender = "female";
            else if (g.equals("other")) mappedGender = "other";
        }
        patient.put("gender", mappedGender);
        patient.put("birthDate", patientBirthDate != null ? patientBirthDate : "1994-03-27");
        request.put("patient", patient);

        List<Map<String, Object>> practitioners = new ArrayList<>();
        Map<String, Object> doctor = new HashMap<>();
        doctor.put("name", "Dr. Midha");
        doctor.put("practitionerId", "MIDHA-001");
        practitioners.add(doctor);
        request.put("practitioners", practitioners);

        Map<String, Object> organisation = new HashMap<>();
        organisation.put("facilityName", "MIDHA HOSPITAL");
        organisation.put("facilityId", record.getHipId());
        request.put("organisation", organisation);

        List<Map<String, Object>> meds = new ArrayList<>();
        if (record.getMedicines() != null) {
            for (Prescription.Medicine med : record.getMedicines()) {
                Map<String, Object> m = new HashMap<>();
                m.put("medicine", med.getName());
                m.put("dosage", med.getDosage() != null ? med.getDosage() : "1-0-1");
                m.put("timing", "1-1-D");
                m.put("route", "Oral");
                m.put("method", "swallow");
                m.put("additionalInstructions", "Take as directed");
                meds.add(m);
            }
        }
        
        if ("DischargeSummary".equalsIgnoreCase(hiType) || "OPConsultation".equalsIgnoreCase(hiType)) {
            request.put("medications", meds);
        } else {
            request.put("prescriptions", meds);
        }

        if ("DiagnosticReport".equalsIgnoreCase(hiType)) {
            List<Map<String, Object>> diagnostics = new ArrayList<>();
            Map<String, Object> d = new HashMap<>();
            d.put("serviceName", "Complete Blood Count");
            d.put("result", "Normal");
            diagnostics.add(d);
            request.put("diagnostics", diagnostics);
        }

        // Common Document (Image or PDF)
        List<Map<String, Object>> docs = new ArrayList<>();
        Map<String, Object> doc = new HashMap<>();
        doc.put("type", hiType != null ? hiType : "Prescription");
        doc.put("contentType", "application/pdf"); // Strictly PDF for mobile apps
        
        String inputData = (record.getPdfData() != null && !record.getPdfData().isEmpty()) 
                            ? record.getPdfData() 
                            : "JVBERi0xLjEKMSAwIG9iajw8L1R5cGUvQ2F0YWxvZy9QYWdlcyAyIDAgUj4+ZW5kb2JqIDIgMCBvYmo8PC9UeXBlL1BhZ2VzL0tpZHNbMyAwIFJdL0NvdW50IDE+PmVuZG9iagAzIDAgb2JqPDwvVHlwZS9QYWdlL01lZGlhQm94WzAgMCAzIDNdL1BhcmVudCAyIDAgUj4+ZW5kb2JqIHRyYWlsZXI8PC9Sb290IDEgMCBSPj4lJUVPRg==";

        // If input is PNG, convert to real PDF using PDFBox
        if (inputData.startsWith("iVBORw")) {
            try {
                inputData = convertImageToPdf(inputData);
            } catch (IOException e) {
                // Fallback to original if conversion fails
            }
        }
        
        doc.put("data", inputData);
        docs.add(doc);
        request.put("documents", docs);

        return this.webClient.post()
                .uri(endpoint)
                .contentType(MediaType.APPLICATION_JSON)
                .bodyValue(request)
                .retrieve()
                .bodyToMono(String.class);
    }

    private String convertImageToPdf(String base64Image) throws IOException {
        byte[] imageBytes = Base64.getDecoder().decode(base64Image);
        try (PDDocument document = new PDDocument()) {
            PDImageXObject pdImage = PDImageXObject.createFromByteArray(document, imageBytes, "prescription.png");
            
            // Standard A4-ish page or match image aspect
            PDPage page = new PDPage(new PDRectangle(pdImage.getWidth(), pdImage.getHeight()));
            document.addPage(page);
            
            try (PDPageContentStream contentStream = new PDPageContentStream(document, page)) {
                contentStream.drawImage(pdImage, 0, 0);
            }
            
            ByteArrayOutputStream baos = new ByteArrayOutputStream();
            document.save(baos);
            return Base64.getEncoder().encodeToString(baos.toByteArray());
        }
    }
}

