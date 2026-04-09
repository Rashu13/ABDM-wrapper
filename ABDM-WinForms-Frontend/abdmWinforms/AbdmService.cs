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
        private static readonly HttpClient client;
        private static readonly string DomainUrl = GlobalConfig.DomainUrl;
        private static readonly string BaseUrl = GlobalConfig.BaseUrl;

        static AbdmService()
        {
            client = new HttpClient();
            // Adding mandatory V3 headers globally
            client.DefaultRequestHeaders.Add("X-HIU-ID", GlobalConfig.HipId);
            client.DefaultRequestHeaders.Add("X-HIP-ID", GlobalConfig.HipId);
        }

        // Step 1: Add Patient to Database
        public async Task<string> AddPatientAsync(PatientModel patient)
        {
            try
            {
                var json = JsonConvert.SerializeObject(new List<PatientModel> { patient });
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // V3 Endpoint: /v3/add-patients
                var response = await client.PutAsync(string.Format("{0}/add-patients", BaseUrl), content);
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
                var response = await client.PostAsync(string.Format("{0}/link-carecontexts", BaseUrl), content);
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
            try
            {
                // Corrected path to match HIPFacadeLinkV3Controller (/v3/link-status/{requestId})
                var response = await client.GetAsync(string.Format("{0}/link-status/{1}", BaseUrl, Uri.EscapeDataString(requestId)));
                var result = await response.Content.ReadAsStringAsync();
                return result;
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
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

                var response = await client.PostAsync(string.Format("{0}/sms/notify", BaseUrl), content);
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
                var response = await client.PostAsync(string.Format("{0}/v1/verify-otp", DomainUrl), content);
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
                // URL encode the ABHA Address (e.g., user@sbx -> user%40sbx)
                string encodedAbha = Uri.EscapeDataString(abhaAddress);
                var response = await client.GetAsync(string.Format("{0}/patient/{1}", BaseUrl, encodedAbha));
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
                var response = await client.GetAsync(string.Format("{0}/patients?hipId={1}", BaseUrl, hipId));
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception)
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
                var response = await client.GetAsync(string.Format("{0}/activities", BaseUrl));
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
                var response = await client.PostAsync(string.Format("{0}/prescriptions", BaseUrl), content);
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        // Step 9: HIU - Request Consent from Patient
        public async Task<FacadeV3Response> RequestConsentAsync(object request)
        {
            var requestId = Guid.NewGuid().ToString();
            try
            {
                var json = JsonConvert.SerializeObject(new { 
                    requestId = requestId,
                    timestamp = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                    consent = request 
                });
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                
                // Using HttpRequestMessage for unique headers
                var httpRequest = new HttpRequestMessage(HttpMethod.Post, string.Format("{0}/consent-init", BaseUrl))
                {
                    Content = content
                };
                httpRequest.Headers.Add("REQUEST-ID", requestId);

                var response = await client.SendAsync(httpRequest);
                var result = await response.Content.ReadAsStringAsync();
                var facadeResponse = JsonConvert.DeserializeObject<FacadeV3Response>(result);
                
                // Ensure clientRequestId is populated for frontend tracking
                if (facadeResponse != null && string.IsNullOrEmpty(facadeResponse.clientRequestId))
                {
                    facadeResponse.clientRequestId = requestId;
                }
                
                return facadeResponse;
            }
            catch (Exception ex) 
            { 
                return new FacadeV3Response { 
                    clientRequestId = requestId,
                    errors = new List<ErrorV3Response> { new ErrorV3Response { error = new ErrorDetail { message = ex.Message } } } 
                }; 
            }
        }

        // Step 9.1: Check Consent Status
        public async Task<ConsentStatusV3Response> GetConsentStatusAsync(string requestId)
        {
            try
            {
                var response = await client.GetAsync(string.Format("{0}/consent-status/{1}", BaseUrl, requestId));
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ConsentStatusV3Response>(result);
            }
            catch (Exception ex) 
            { 
                return new ConsentStatusV3Response { errors = new List<ErrorV3Response> { new ErrorV3Response { error = new ErrorDetail { message = ex.Message } } } }; 
            }
        }

        // Step 10: HIU - Fetch Health Records after consent grant
        public async Task<FacadeV3Response> FetchRecordsAsync(string consentId)
        {
            var requestId = Guid.NewGuid().ToString();
            try
            {
                var payload = new 
                { 
                    requestId = requestId,
                    timestamp = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                    requesterId = GlobalConfig.HipId, // Java requires requesterId instead of hiuId!
                    consentId = consentId
                };
                var content = new StringContent(JsonConvert.SerializeObject(payload), System.Text.Encoding.UTF8, "application/json");
                
                // V3 requires specific headers for health info request
                var httpRequest = new HttpRequestMessage(HttpMethod.Post, string.Format("{0}/health-information/fetch-records", BaseUrl))
                {
                    Content = content
                };
                httpRequest.Headers.Add("X-HIU-ID", GlobalConfig.HipId);
                httpRequest.Headers.Add("REQUEST-ID", requestId);

                var response = await client.SendAsync(httpRequest);
                var result = await response.Content.ReadAsStringAsync();
                var facadeResponse = JsonConvert.DeserializeObject<FacadeV3Response>(result);
                
                if (facadeResponse != null && string.IsNullOrEmpty(facadeResponse.clientRequestId))
                {
                    facadeResponse.clientRequestId = requestId;
                }
                
                return facadeResponse;
            }
            catch (Exception ex) 
            { 
                return new FacadeV3Response { 
                    clientRequestId = requestId,
                    errors = new List<ErrorV3Response> { new ErrorV3Response { error = new ErrorDetail { message = ex.Message } } } 
                }; 
            }
        }

        // Step 10.1: Check Health Information Status (and get decrypted bundles)
        public async Task<HealthInformationV3Response> GetHealthInformationStatusAsync(string requestId)
        {
            try
            {
                var response = await client.GetAsync(string.Format("{0}/health-information/status/{1}", BaseUrl, requestId));
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<HealthInformationV3Response>(result);
            }
            catch (Exception ex) { return new HealthInformationV3Response { errors = new List<ErrorV3Response> { new ErrorV3Response { error = new ErrorDetail { message = ex.Message } } } }; }
        }
    }
}
