﻿namespace DatabaseModels.Models
{
    public class User
    {
        int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } // ADMIN, DOCTOR, NURSE

    }
}
