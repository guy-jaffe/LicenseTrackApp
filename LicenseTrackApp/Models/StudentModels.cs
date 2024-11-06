 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseTrackApp.Models
{
    public class StudentModels:UsersModels
    {
        public string Street { get; set; }
        public DateOnly? LicenseAcquisitionDate { get; set; }
        public int? LicenseStatus { get; set; } // Consider using an enum for better clarity

        public StudentModels() { }
        
    }
}
