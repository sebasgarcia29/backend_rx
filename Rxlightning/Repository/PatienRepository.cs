using Rxlightning.Extensions;
using Rxlightning.Interface;
using Rxlightning.WebApi.Models;

namespace Rxlightning.Repository
{
    internal class PatientRepository : IPatientRepository
    {
        private readonly IPatientsHttp _patientsDataProvider;


        public PatientRepository(IPatientsHttp patientsDataProvider)
        {
            _patientsDataProvider = patientsDataProvider;
        }


        public async Task<IEnumerable<Patient>> GetAllAsync()
        {
            var patients = await _patientsDataProvider.GetAllAsync();

            var patientsFormatted = patients.Select(patient =>
            {
                patient.PatientId = patient.PatientId.EncodeId();

                return patient;
            });

            return patientsFormatted;
        }

        public async Task<Patient> GetByIdAsync(string id)
        {
            var patientId = id.DecodeId();

            var patient = await _patientsDataProvider.GetByIdAsync(patientId);

            if (patient != null)
            {
                patient.PatientId = id.DecodeId();
            }

            return patient;
        }
    }
}
