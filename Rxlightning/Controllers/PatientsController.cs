using Rxlightning.WebApi.Interface;
using Rxlightning.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Rxlightning.WebApi.Controllers
{
    [Authorize]
    [Route("api/patient")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatient _IPatient;

        public PatientController(IPatient IPatient)
        {
            _IPatient = IPatient;
        }

        // GET: api/patient>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> Get()
        {
            return await Task.FromResult(_IPatient.GetPatientDetails());
        }

        // GET api/patient/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> Get(Guid id)
        {
            var patients = await Task.FromResult(_IPatient.GetPatientDetails(id));
            if (patients == null)
            {
                return NotFound();
            }
            return patients;
        }

        // POST api/patient
        [HttpPost]
        public async Task<ActionResult<Patient>> Post(Patient patient)
        {
            _IPatient.AddPatient(patient);
            return await Task.FromResult(patient);
        }

        // PUT api/patient/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Patient>> Put(Guid id, Patient patient)
        {
            if (id != patient.patientId)
            {
                return BadRequest();
            }
            try
            {
                _IPatient.UpdatePatient(patient);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatienExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return await Task.FromResult(patient);
        }

        // DELETE api/patient/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Patient>> Delete(Guid id)
        {
            var patient = _IPatient.DeletePatient(id);
            return await Task.FromResult(patient);
        }

        private bool PatienExists(Guid id)
        {
            return _IPatient.CheckPatient(id);
        }
    }
}