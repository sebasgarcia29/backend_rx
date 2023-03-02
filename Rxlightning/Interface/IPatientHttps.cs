using Rxlightning.WebApi.Models;

namespace Rxlightning.Interface
{
    public interface IPatientsHttp
    {
        Task<Patient> GetByIdAsync(string patientId);
        Task<IEnumerable<Patient>> GetAllAsync();
    }
}
