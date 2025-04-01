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

        public string LicenseStatusName
        {
            get
            {
                if (this.LicenseStatus == null)
                {
                    return "לא ידוע";
                }
                if (this.LicenseStatus == 0)
                {
                    return "תאוריה";
                }
                if (this.LicenseStatus == 1)
                {
                    return "שיעורי נהיגה";
                }
                if (this.LicenseStatus == 1)
                {
                    return "מלווה";
                }
                else
                    return "נהג עצמאי";
            }
        }
        public StudentModels() { }
        
    }
}
