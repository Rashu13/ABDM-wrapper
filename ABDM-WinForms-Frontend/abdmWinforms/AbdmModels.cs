using System;
using System.Collections.Generic;

namespace ABDM_WinForms_Frontend
{
    public class PatientModel
    {
        public string abhaAddress { get; set; }
        public string abhaNumber { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public string dateOfBirth { get; set; }
        public string patientMobile { get; set; }
        public string patientReference { get; set; }
        public string patientDisplay { get; set; }
        public string hipId { get; set; }
        public List<CareContext> careContexts { get; set; }
    }

    public class CareContext
    {
        public string referenceNumber { get; set; }
        public string display { get; set; }
        public string hiType { get; set; }
    }

    public class LinkRequest
    {
        public string requestId { get; set; }
        public string requesterId { get; set; }
        public string abhaAddress { get; set; }
        public List<CareContext> careContexts { get; set; }
    }

    public class ApiResponse
    {
        public string message { get; set; }
        public string clientRequestId { get; set; }
    }

    public class FacadeV3Response
    {
        public string clientRequestId { get; set; }
        public string httpStatusCode { get; set; }
        public List<ErrorV3Response> errors { get; set; }
    }

    public class ErrorV3Response
    {
        public ErrorDetail error { get; set; }
    }

    public class ErrorDetail
    {
        public string code { get; set; }
        public string message { get; set; }
    }

    public class HealthInformationV3Response
    {
        public string status { get; set; }
        public List<DecryptedHealthInformationEntry> decryptedHealthInformationEntries { get; set; }
        public List<ErrorV3Response> errors { get; set; }
    }

    public class DecryptedHealthInformationEntry
    {
        public string careContextReference { get; set; }
        public string bundleContent { get; set; }
    }

    public class HealthRecordSummary
    {
        public string Date { get; set; }
        public string Type { get; set; }
        public string Provider { get; set; }
        public string ContentHtml { get; set; }
        public string RawJson { get; set; }
    }

    // --- HIU CONSENT MODELS ---

    public class ConsentStatusV3Response
    {
        public string status { get; set; } // Top level status like CONSENT_FETCH_ACCEPTED
        public string httpStatusCode { get; set; }
        public FacadeConsentDetails consentDetails { get; set; }
        public List<ErrorV3Response> errors { get; set; }
    }

    public class FacadeConsentDetails
    {
        public List<ConsentStatusDetail> consent { get; set; }
    }

    public class ConsentStatusDetail
    {
        public string status { get; set; } // GRANTED, etc.
        public List<ConsentArtefactV3> consentArtefacts { get; set; }
    }

    public class ConsentArtefactV3
    {
        public string id { get; set; } // This is the actual Consent ID
        public string lastUpdated { get; set; }
    }

    public class PrescriptionModel
    {
        public string abhaAddress { get; set; }
        public string patientName { get; set; }
        public string date { get; set; }
        public List<MedicineModel> medicines { get; set; }
        public string hipId { get; set; }
    }

    public class MedicineModel
    {
        public string name { get; set; }
        public string dosage { get; set; }
        public string duration { get; set; }
    }

    public class ConsentRequestTracker
    {
        public string RequestId { get; set; }
        public string PatientName { get; set; }
        public string Status { get; set; }
        public string ConsentId { get; set; }
    }

    public static class GlobalState
    {
        public static List<ConsentRequestTracker> ActiveConsentRequests = new List<ConsentRequestTracker>();
    }
}
