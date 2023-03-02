using Microsoft.VisualBasic;
using Rxlightning.Interface;
using Rxlightning.WebApi.Models;

namespace Rxlightning.Repository
{
    internal class PatientsHttps : IPatientsHttp
    {
        private readonly IHttpClientFactory _httpClientFactory;


        public PatientsHttps(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<Patient>> GetAllAsync()
        {
            using var httpClient = GetHttpClient();
            var patients = await httpClient.GetFromJsonAsync<Patient[]>("patients");

            return patients ?? Enumerable.Empty<Patient>();
        }

        public async Task<Patient> GetByIdAsync(string patientId)
        {
            Patient patient = null;

            if (!string.IsNullOrWhiteSpace(patientId))
            {
                using var httpClient = GetHttpClient();
                var response = await httpClient.GetAsync($"patient/{patientId}");


                if (response.IsSuccessStatusCode)
                {
                    patient = await response.Content.ReadFromJsonAsync<Patient>();
                }
            }

            return patient;
        }

        private HttpClient GetHttpClient()
        {
            var httpClient = _httpClientFactory.CreateClient("PatientsHttpClient");

            return httpClient;
        }
    }
}
