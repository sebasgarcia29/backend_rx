using Rxlightning.WebApi.Interface;
using Rxlightning.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Rxlightning.WebApi.Repository
{
    public class PatientsRepository : IPatient
    {
        readonly DatabaseContext _dbContext = new();

        public PatientsRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Patient> GetPatientDetails()
        {
            try
            {
                return _dbContext.Patients.ToList();
            }
            catch
            {
                throw;
            }
        }

        public Patient GetPatientDetails(Guid id)
        {
            try
            {
                Patient patients = _dbContext.Patients.Find(id);
                if (patients != null)
                {
                    return patients;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public void AddPatient(Patient patients)
        {
            try
            {
                _dbContext.Patients.Add(patients);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void UpdatePatient(Patient patients)
        {
            try
            {
                _dbContext.Entry(patients).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public Patient DeletePatient(Guid id)
        {
            try
            {
                Patient patients = _dbContext.Patients.Find(id);

                if (patients != null)
                {
                    _dbContext.Patients.Remove(patients);
                    _dbContext.SaveChanges();
                    return patients;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public bool CheckPatient(Guid id)
        {
            return _dbContext.Patients.Any(e => e.patientId == id);
        }
    }
}