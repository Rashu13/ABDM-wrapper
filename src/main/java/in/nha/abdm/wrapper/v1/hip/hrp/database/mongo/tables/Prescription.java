/* (C) 2024 */
package in.nha.abdm.wrapper.v1.hip.hrp.database.mongo.tables;

import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;
import org.springframework.data.annotation.Id;
import org.springframework.data.mongodb.core.mapping.Document;
import java.util.List;

@Data
@Document(collection = "prescriptions")
@AllArgsConstructor
@NoArgsConstructor
@Builder
public class Prescription {
  @Id private String id;
  private String abhaAddress;
  private String patientName;
  private String date;
  private String gender;
  private String birthDate;
  private String careContextReference;
  private String patientReference;
  private List<Medicine> medicines;
  private String hipId;
  private String hiType; // Standard ABDM HI Types: Prescription, DiagnosticReport, etc.
  private String pdfData; // Base64 encoded PDF data from WinForms

  @Data
  public static class Medicine {
    private String name;
    private String dosage; // e.g., 1-0-1
    private String duration; // e.g., 5 days
  }
}
