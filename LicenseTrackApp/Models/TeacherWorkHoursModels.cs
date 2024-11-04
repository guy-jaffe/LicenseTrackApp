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
        public TeacherWorkHoursModels(Models.TeacherWorkHoursModels modelTeacherWorkHour)
        {
            this.TeacherId = modelTeacherWorkHour.TeacherId;
            this.DayDate = modelTeacherWorkHour.DayDate;
            this.StartTime = modelTeacherWorkHour.StartTime;
            this.EndTime = modelTeacherWorkHour.EndTime;
        }

        public Models.TeacherWorkHoursModels GetModels()
        {
            Models.TeacherWorkHoursModels modelTeacherWorkHour = new Models.TeacherWorkHoursModels()
            {
                TeacherId = this.TeacherId,
                DayDate = this.DayDate,
                StartTime = this.StartTime,
                EndTime = this.EndTime
            };

            return modelTeacherWorkHour;
        }
    }
}
