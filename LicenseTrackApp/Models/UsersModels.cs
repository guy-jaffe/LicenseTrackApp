using LicenseTrackApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseTrackApp.Models
{
    public class UsersModels
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PasswordHash { get; set; }
        public string? City { get; set; }
        public string FileExtension { get; set; }
        public bool IsManager { get; set; }
        public string? PhoneNum { get; set; }

        public string ProfileImagePath { get; set; } = "";

        public string ProfileImageUrl
        {
            get
            {
                return LicenseTrackWebAPIProxy.ImageBaseAddress + ProfileImagePath;
            }
        }

        public UsersModels() { }
       

            
    }
}
