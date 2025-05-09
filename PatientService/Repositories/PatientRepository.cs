using System.Collections.Generic;
using System.Linq;
using DatabaseModels.Models;
using PatientService.Interfaces;
using DatabaseModels.DTO;
using DatabaseModels.Data;
using Microsoft.EntityFrameworkCore;

namespace PatientService.Repositories
    {
        public class PatientRepository : IPatientRepository
        {
        
            private readonly HealthcareContext _context;
            public PatientRepository(HealthcareContext context) {
                _context = context;
            }

        public IEnumerable<Patient> GetPatient()
            {
                return _context.Patients.ToList();
            }
        public async Task<Patient> GetPatientById(int id)
            {
                return await _context.Patients.FirstOrDefaultAsync(p => p.Id == id);
            }
        public async Task<Patient> GetPatientByName(string name)
            {
                return await _context.Patients.FirstOrDefaultAsync(p => p.Name == name);
            }

        public  async Task<Patient> AddPatient(PatientDTO patientDTO) {
            var patient =  await _context.Patients.FirstOrDefaultAsync(p => p.Email == patientDTO.Email);
            if (patient != null)
            {
                return null; // User already exists
            }
            var newPatient = new Patient
            {
                Name = patientDTO.Name,
                Email = patientDTO.Email,
                Phone = patientDTO.Phone,
                Interactions = patientDTO.Interactions
            };
            _context.Patients.Add(newPatient);
            _context.SaveChanges();
            return newPatient;
            }
        public async Task<Patient> UpdatePatient(int id, PatientDTO patientDTO)
            {
                var patient = await _context.Patients.FirstOrDefaultAsync(p => p.Id == id);
                if (patient == null)
                {
                    return null;
                }
                patient.Name = patientDTO.Name;
                patient.Email = patientDTO.Email;
                patient.Phone = patientDTO.Phone;
                _context.SaveChanges();
                return patient;
            }
        public async Task<Patient> UpdatePatientInteractions(int id, string interactions)
            {
                var patient = await _context.Patients.FirstOrDefaultAsync(p => p.Id == id);
                if (patient == null)
                {
                    return null;
                }
                patient.Interactions = interactions;
                _context.SaveChanges();
                return patient;
            }
        public bool DeletePatient(int id)
            {
                var patient = _context.Patients.FirstOrDefault(p => p.Id == id);
                if (patient == null)
                {
                    return false;
                }
                _context.Patients.Remove(patient);
                _context.SaveChanges();
                return true;
            }
        }
    }


