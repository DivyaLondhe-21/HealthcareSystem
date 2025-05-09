using DatabaseModels.DTO;
using DatabaseModels.Models;

namespace PatientService.Interfaces

{
    public interface IPatientRepository
    {
        IEnumerable<Patient> GetPatient();
        Task<Patient> GetPatientById(int id);
        Task<Patient> GetPatientByName(string name);
        Task<Patient> AddPatient(PatientDTO patient);
        Task<Patient> UpdatePatient(int id, PatientDTO patient);
        Task<Patient> UpdatePatientInteractions(int id, string interactions);
        bool DeletePatient(int id);
    }
}
