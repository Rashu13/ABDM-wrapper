using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using ABDM_WinForms_Frontend;

namespace abdmWinforms
{
    public class FhirParser
    {
        public static List<HealthRecordSummary> ParseBundle(string bundleJson)
        {
            var summaries = new List<HealthRecordSummary>();
            try
            {
                JObject bundle = JObject.Parse(bundleJson);
                var entries = bundle["entry"] as JArray;
                if (entries == null) return summaries;

                // 1. Get Organization (Provider)
                string provider = "Unknown Provider";
                var org = entries.FirstOrDefault(e => e["resource"]?["resourceType"]?.ToString() == "Organization");
                if (org != null)
                {
                    provider = org["resource"]?["name"]?.ToString() ?? provider;
                }

                // 2. Look for Composition (the document header)
                var composition = entries.FirstOrDefault(e => e["resource"]?["resourceType"]?.ToString() == "Composition");
                string docType = "Medical Record";
                string docDate = DateTime.Now.ToString("dd-MMM-yyyy");

                if (composition != null)
                {
                    var resource = composition["resource"];
                    docType = resource["type"]?["text"]?.ToString() ?? resource["title"]?.ToString() ?? docType;
                    docDate = TryParseDate(resource["date"]?.ToString()) ?? docDate;
                }

                // 3. Extract Clinical Content
                StringBuilder details = new StringBuilder();
                details.AppendLine($"--- {docType} ---");
                details.AppendLine($"Date: {docDate}");
                details.AppendLine($"Facility: {provider}");
                details.AppendLine();

                // Medications
                var medications = entries.Where(e => e["resource"]?["resourceType"]?.ToString() == "MedicationRequest");
                if (medications.Any())
                {
                    details.AppendLine("MEDICATIONS:");
                    foreach (var med in medications)
                    {
                        var res = med["resource"];
                        string name = res["medicationCodeableConcept"]?["text"]?.ToString() ?? "Unknown Medicine";
                        string dosage = res["dosageInstruction"]?[0]?["text"]?.ToString() ?? "";
                        details.AppendLine($"- {name} {dosage}");
                    }
                    details.AppendLine();
                }

                // Observations
                var observations = entries.Where(e => e["resource"]?["resourceType"]?.ToString() == "Observation");
                if (observations.Any())
                {
                    details.AppendLine("OBSERVATIONS:");
                    foreach (var obs in observations)
                    {
                        var res = obs["resource"];
                        string name = res["code"]?["text"]?.ToString() ?? "Observation";
                        string val = res["valueQuantity"]?["value"]?.ToString() ?? res["valueString"]?.ToString() ?? "";
                        string unit = res["valueQuantity"]?["unit"]?.ToString() ?? "";
                        details.AppendLine($"- {name}: {val} {unit}");
                    }
                    details.AppendLine();
                }

                // Conditions
                var conditions = entries.Where(e => e["resource"]?["resourceType"]?.ToString() == "Condition");
                if (conditions.Any())
                {
                    details.AppendLine("DIAGNOSIS / CONDITIONS:");
                    foreach (var cond in conditions)
                    {
                        var res = cond["resource"];
                        string name = res["code"]?["text"]?.ToString() ?? "Condition";
                        details.AppendLine($"- {name}");
                    }
                    details.AppendLine();
                }

                // Diagnostic Reports (Lab/Imaging)
                var reports = entries.Where(e => e["resource"]?["resourceType"]?.ToString() == "DiagnosticReport");
                if (reports.Any())
                {
                    details.AppendLine("DIAGNOSTIC REPORTS:");
                    foreach (var rep in reports)
                    {
                        var res = rep["resource"];
                        string name = res["code"]?["text"]?.ToString() ?? "Lab Report";
                        string status = res["status"]?.ToString() ?? "";
                        details.AppendLine($"- {name} ({status})");
                    }
                    details.AppendLine();
                }

                // Procedures
                var procedures = entries.Where(e => e["resource"]?["resourceType"]?.ToString() == "Procedure");
                if (procedures.Any())
                {
                    details.AppendLine("PROCEDURES:");
                    foreach (var proc in procedures)
                    {
                        var res = proc["resource"];
                        string name = res["code"]?["text"]?.ToString() ?? "Procedure";
                        string date = TryParseDate(res["performedDateTime"]?.ToString()) ?? "";
                        details.AppendLine($"- {name} {date}");
                    }
                    details.AppendLine();
                }

                // Immunizations
                var immunizations = entries.Where(e => e["resource"]?["resourceType"]?.ToString() == "Immunization");
                if (immunizations.Any())
                {
                    details.AppendLine("IMMUNIZATIONS:");
                    foreach (var imm in immunizations)
                    {
                        var res = imm["resource"];
                        string name = res["vaccineCode"]?["text"]?.ToString() ?? "Vaccine";
                        string status = res["status"]?.ToString() ?? "";
                        details.AppendLine($"- {name} ({status})");
                    }
                    details.AppendLine();
                }

                // Allergy Intolerance
                var allergies = entries.Where(e => e["resource"]?["resourceType"]?.ToString() == "AllergyIntolerance");
                if (allergies.Any())
                {
                    details.AppendLine("ALLERGIES & INTOLERANCE:");
                    foreach (var allergy in allergies)
                    {
                        var res = allergy["resource"];
                        string name = res["code"]?["text"]?.ToString() ?? "Allergy";
                        string criticality = res["criticality"]?.ToString() ?? "Unknown";
                        details.AppendLine($"- {name} (Criticality: {criticality})");
                    }
                    details.AppendLine();
                }

                summaries.Add(new HealthRecordSummary
                {
                    Date = docDate,
                    Type = docType,
                    Provider = provider,
                    ContentHtml = details.ToString(),
                    RawJson = bundleJson
                });

            }
            catch (Exception ex)
            {
                summaries.Add(new HealthRecordSummary
                {
                    Date = DateTime.Now.ToString("dd-MMM-yyyy"),
                    Type = "ERROR",
                    Provider = "Parser",
                    ContentHtml = "Failed to parse FHIR bundle: " + ex.Message,
                    RawJson = bundleJson
                });
            }

            return summaries;
        }

        private static string TryParseDate(string dateStr)
        {
            if (string.IsNullOrEmpty(dateStr)) return null;
            if (DateTime.TryParse(dateStr, out DateTime dt))
            {
                return dt.ToString("dd-MMM-yyyy");
            }
            return dateStr;
        }
    }
}
