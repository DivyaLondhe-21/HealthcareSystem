using Microsoft.AspNetCore.Mvc;
using DatabaseModels.Models;
using DatabaseModels.DTO;
using PatientService.Interfaces;
//using AuthService.JwtService;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Text;

namespace PatientService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {

        //private readonly JwtToken _jwtToken;
        private readonly IPatientRepository _patientRepository;
        public PatientController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        
        // Get all users (for testing, can be removed in production)
        [HttpGet]
        public ActionResult<IEnumerable<Patient>> GetPatient()
        {
            var patients = _patientRepository.GetPatient();
            return Ok(patients);
        }

        // Get a specific user
        [HttpGet("{id}")]
        public ActionResult<Patient> GetpatientbyId(int id)
        {
            var patient = _patientRepository.GetPatientById(id);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }

        [HttpGet("{name}")]
        public ActionResult<Patient> GetpatientbyName(string name)
        {
            var patient = _patientRepository.GetPatientByName(name);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }
        // Update user info
        [HttpPut("update/patient/{id}")]
        public IActionResult UpdatePatientData(int id, PatientDTO updatePatient)
        {
            var patient = _patientRepository.UpdatePatient(id, updatePatient);
            if (patient == null)
            {
                return NotFound();
            }
           
            return NoContent();
        }

        [HttpPut("update/interaction/{id}")]
        public IActionResult UpdatePatientInteractions(int id, string interactions)
        {
            var patient = _patientRepository.UpdatePatientInteractions(id, interactions);
            if (patient == null)
            {
                return NotFound();
            }

            return NoContent();
        }
        // Delete user
        [HttpDelete("{id}")]
        public IActionResult DeletePatientData(int id)
        {
            var isDeleted = _patientRepository.DeletePatient(id);
            if (isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }

    // Simple Login Request Model

}
