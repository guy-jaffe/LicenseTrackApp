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
        public string City { get; set; }
        public string FileExtension { get; set; }
        public bool IsManager { get; set; }



        public UsersModels() { }
        public UsersModels(Models.UsersModels modelUser)
        {
            this.Id = modelUser.Id;
            this.Email = modelUser.Email;
            this.FirstName = modelUser.FirstName;
            this.LastName = modelUser.LastName;
            this.PasswordHash = modelUser.PasswordHash;
            this.City = modelUser.City;
            this.FileExtension = modelUser.FileExtension;
            this.IsManager = modelUser.IsManager;
        }

        public Models.UsersModels GetModels()
        {
            Models.UsersModels modelUser = new Models.UsersModels()
            {
                Id = this.Id,
                Email = this.Email,
                FirstName = this.FirstName,
                LastName = this.LastName,
                PasswordHash = this.PasswordHash,
                City = this.City,
                FileExtension = this.FileExtension,
                IsManager = this.IsManager
            };

            return modelUser;
        }
    }
}
