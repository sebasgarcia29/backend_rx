using Rxlightning.WebApi.Models;

namespace Rxlightning.Interface
{
    public interface IPatientRepository
    {
        Task<Patient> GetByIdAsync(string id);
        Task<IEnumerable<Patient>> GetAllAsync();
    }
}
