using System;
using System.Collections.Generic;

namespace ABDM_WinForms_Frontend
{
    public class PatientModel
    {
        public string abhaAddress { get; set; }
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
}
