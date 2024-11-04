using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseTrackApp.Models
{
    public class TeacherModels
    {
        public int Id { get; set; }
        public string SchoolName { get; set; }
        public bool? ManualCar { get; set; }
        public string VehicleType { get; set; }
        public string TeachingArea { get; set; }
        public bool? ConfirmationStatus { get; set; }


        public TeacherModels() { }
        public TeacherModels(Models.TeacherModels modelTeacher)
        {
            this.Id = modelTeacher.Id;
            this.SchoolName = modelTeacher.SchoolName;
            this.ManualCar = modelTeacher.ManualCar;
            this.VehicleType = modelTeacher.VehicleType;
            this.TeachingArea = modelTeacher.TeachingArea;
            this.ConfirmationStatus = modelTeacher.ConfirmationStatus;
        }

        public Models.TeacherModels GetModels()
        {
            Models.TeacherModels modelTeacher = new Models.TeacherModels()
            {
                Id = this.Id,
                SchoolName = this.SchoolName,
                ManualCar = this.ManualCar,
                VehicleType = this.VehicleType,
                TeachingArea = this.TeachingArea,
                ConfirmationStatus = this.ConfirmationStatus
            };

            return modelTeacher;
        }
    }
}
