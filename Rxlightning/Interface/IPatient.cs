using Rxlightning.WebApi.Models;

namespace Rxlightning.WebApi.Interface
{
    public interface IPatient
    {
        public List<Patient> GetPatientDetails();
        public Patient GetPatientDetails(Guid id);
        public void AddPatient(Patient patient);
        public void UpdatePatient(Patient patient);
        public Patient DeletePatient(Guid id);
        public bool CheckPatient(Guid id);
    }
}