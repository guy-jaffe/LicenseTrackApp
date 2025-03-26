using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseTrackApp.Models
{
    public class TeacherModels : UsersModels
    {
        public string SchoolName { get; set; }
        public bool? ManualCar { get; set; }
        public string VehicleType { get; set; }
        public string TeachingArea { get; set; }
        public int? ConfirmationStatus { get; set; }


        public TeacherModels() { }
        
    }
}
