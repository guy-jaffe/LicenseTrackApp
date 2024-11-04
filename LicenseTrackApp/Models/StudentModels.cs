using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseTrackApp.Models
{
    public class StudentModels
    {
        public int Id { get; set; }
        public int? LessonCount { get; set; }
        public string Street { get; set; }
        public DateOnly? LicenseAcquisitionDate { get; set; }
        public int? LicenseStatus { get; set; } // Consider using an enum for better clarity

        public StudentModels() { }
        public StudentModels(Models.StudentModels modelStudent)
        {
            this.Id = modelStudent.Id;
            this.LessonCount = modelStudent.LessonCount;
            this.Street = modelStudent.Street;
            this.LicenseAcquisitionDate = modelStudent.LicenseAcquisitionDate;
            this.LicenseStatus = modelStudent.LicenseStatus;
        }

        public Models.StudentModels GetModels()
        {
            Models.StudentModels modelStudent = new Models.StudentModels()
            {
                Id = this.Id,
                LessonCount = this.LessonCount,
                Street = this.Street,
                LicenseAcquisitionDate = this.LicenseAcquisitionDate,
                LicenseStatus = this.LicenseStatus
            };

            return modelStudent;
        }
    }
}
