using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseTrackApp.Models
{
    public class TeacherWorkHoursModels
    {
        public int TeacherId { get; set; }
        public DateOnly DayDate { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly? EndTime { get; set; }


        public TeacherWorkHoursModels() { }
        
    }
}
