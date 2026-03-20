using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json; // Using Newtonsoft.Json for .NET 4.5 compatibility

namespace ABDM_WinForms_Frontend
{
    public class AbdmService
    {
        private static readonly HttpClient client = new HttpClient();
        // Domain and Base both point to GlobalConfig
        private static readonly string DomainUrl = GlobalConfig.DomainUrl;
        private static readonly string BaseUrl = GlobalConfig.BaseUrl;

        // Step 1: Add Patient to Database
        public async Task<string> AddPatientAsync(PatientModel patient)
        {
            try
            {
                var json = JsonConvert.SerializeObject(new List<PatientModel> { patient });
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // V3 Endpoint: /v3/add-patients
                var response = await client.PutAsync($"{BaseUrl}/add-patients", content);
                var result = await response.Content.ReadAsStringAsync();

                return result;
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        // Step 2: Initiate Linking (Generate Token/OTP)
        public async Task<string> InitiateLinkingAsync(LinkRequest request)
        {
            try
            {
                var json = JsonConvert.SerializeObject(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // V3 Endpoint: /v3/link-carecontexts
                var response = await client.PostAsync($"{BaseUrl}/link-carecontexts", content);
                var result = await response.Content.ReadAsStringAsync();

                return result;
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        // Step 2.1: Check Linking Status
        public async Task<string> GetLinkStatusAsync(string requestId)
        {
            // Corrected path to match HIPFacadeLinkV3Controller (/v3/link-status/{requestId})
            var response = await client.GetAsync($"{BaseUrl}/link-status/{requestId}");
            return await response.Content.ReadAsStringAsync();
        }

        // Step 3: SMS Notify (Quick Invite)
        public async Task<string> SendSmsNotifyAsync(string abhaAddress, string mobile, string hipId)
        {
            try
            {
                var payload = new
                {
                    requestId = Guid.NewGuid().ToString(),
                    timestamp = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                    notification = new
                    {
                        phoneNo = mobile,
                        hip = new { name = "RAVI HOSPITAL", id = hipId }
                    }
                };

                var json = JsonConvert.SerializeObject(payload);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync($"{BaseUrl}/sms/notify", content);
                var result = await response.Content.ReadAsStringAsync();

                return result;
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        // Step 4: Confirm Linking with OTP
        public async Task<string> ConfirmLinkAsync(string requestId, string otp, string linkRefNumber)
        {
            try
            {
                var payload = new 
                { 
                    requestId = requestId, 
                    authCode = otp, 
                    linkRefNumber = linkRefNumber, 
                    loginHint = "hipLinking" 
                };
                var json = JsonConvert.SerializeObject(payload);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // Correcting to V1 endpoint: /v1/verify-otp
                var response = await client.PostAsync($"{DomainUrl}/v1/verify-otp", content);
                var result = await response.Content.ReadAsStringAsync();

                return result;
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }
        // Step 5: Search Patient by ABHA Address
        public async Task<string> SearchPatientAsync(string abhaAddress)
        {
            try
            {
                // Calling: GET /v3/patient/{abhaAddress}
                var response = await client.GetAsync($"{BaseUrl}/patient/{abhaAddress}");
                var result = await response.Content.ReadAsStringAsync();

                return result;
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        // Step 6: Get All Patients (Activity Logs)
        public async Task<string> GetAllPatientsAsync(string hipId)
        {
            try
            {
                // Calling: GET /v3/patients?hipId=...
                var response = await client.GetAsync($"{BaseUrl}/patients?hipId={hipId}");
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return "[]";
            }
        }

        // Step 7: Get Live Activity Feed (For M3 Sandbox Testing)
        public async Task<string> GetActivitiesAsync()
        {
            try
            {
                // Calling our debug endpoint: GET /v3/activities
                var response = await client.GetAsync($"{BaseUrl}/activities");
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception)
            {
                return "[]";
            }
        }

        // Step 8: Save & Push Prescription to ABDM
        public async Task<string> SavePrescriptionAsync(object prescription)
        {
            try
            {
                // Calling: POST /v3/prescriptions
                var content = new StringContent(JsonConvert.SerializeObject(prescription), System.Text.Encoding.UTF8, "application/json");
                var response = await client.PostAsync($"{BaseUrl}/prescriptions", content);
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        // Step 9: HIU - Request Consent from Patient
        public async Task<string> RequestConsentAsync(object request)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(new { consent = request }), System.Text.Encoding.UTF8, "application/json");
                // Correct path from FacadeURL.java: /consent-init
                var response = await client.PostAsync($"{BaseUrl}/consent-init", content);
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex) { return "Error: " + ex.Message; }
        }

        // Step 9.1: Check Consent Status
        public async Task<string> GetConsentStatusAsync(string requestId)
        {
            try
            {
                var response = await client.GetAsync($"{BaseUrl}/consent-status/{requestId}");
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex) { return "Error: " + ex.Message; }
        }

        // Step 10: HIU - Fetch Health Records after consent grant
        public async Task<string> FetchRecordsAsync(string consentId)
        {
            try
            {
                var payload = new 
                { 
                    requestId = Guid.NewGuid().ToString(),
                    timestamp = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                    hiuId = GlobalConfig.HipId, // Usually HIU ID
                    consentId = consentId
                };
                var content = new StringContent(JsonConvert.SerializeObject(payload), System.Text.Encoding.UTF8, "application/json");
                
                // Correct path from FacadeURL.java: /v3/health-information/fetch-records
                // Note: /v3 is already in BaseUrl
                var response = await client.PostAsync($"{BaseUrl}/health-information/fetch-records", content);
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex) { return "Error: " + ex.Message; }
        }

        // Step 10.1: Check Health Information Status (and get decrypted bundles)
        public async Task<string> GetHealthInformationStatusAsync(string requestId)
        {
            try
            {
                // Correct path from FacadeURL.java: /v3/health-information/status/{requestId}
                var response = await client.GetAsync($"{BaseUrl}/health-information/status/{requestId}");
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex) { return "Error: " + ex.Message; }
        }
    }
}
