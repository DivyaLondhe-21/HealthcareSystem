using System.Collections.Generic;
using System.Linq;
using DatabaseModels.Models;
using AuthenticationService.Interfaces;
using DatabaseModels.DTO;
using DatabaseModels.Data;

namespace AuthenticationService.Repositories
    {
        public class AuthRepository : IAuthRepository
        {
        
            private readonly HealthcareContext _context;
            public AuthRepository(HealthcareContext context) {
                _context = context;
            }

            public User Login(LoginDTO loginDTO)
            {
            User userData = _context.Users.FirstOrDefault(u => u.Username == loginDTO.Username && u.Password == loginDTO.Password);
            if (userData == null)
            {
                return null;
            }
                return userData;
            }
        }
    }


