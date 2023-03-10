using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rxlightning.Interface;
using Rxlightning.WebApi.Models;

namespace Onetree.RxLightning.SeniorTechInterview.Al3xCubillos.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("patients")]
    [Produces("application/json")]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;
        private readonly ILogger<PatientsController> _logger;

        public PatientsController(IPatientRepository patientService, ILogger<PatientsController> logger)
        {
            _patientRepository = patientService;
            _logger = logger;
        }

        [HttpGet("")]
        public async Task<IEnumerable<Patient>> Get()
        {
            var patients = await _patientRepository.GetAllAsync().ConfigureAwait(false);

            return patients;
        }

        [HttpGet("/patient/{patientId}")]
        [ProducesResponseType(typeof(Patient), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAsync(string patientId)
        {
            var patient = await _patientRepository.GetByIdAsync(patientId).ConfigureAwait(false);

            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }
    }
}