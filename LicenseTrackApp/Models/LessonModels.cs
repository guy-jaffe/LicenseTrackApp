using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseTrackApp.Models
{
    public class LessonModels
    {
        public int Id { get; set; }
        public DateOnly? LessonDate { get; set; }
        public TimeOnly? LessonTime { get; set; }
        public string LessonType { get; set; }
        public int? StudentId { get; set; }
        public StudentModels? Student { get; set; }
        public int? InstructorId { get; set; }
        public TeacherModels? Instructor { get; set; }
        public string? Comments { get; set; }

        public string StudentName
        {
            get
            {
                if (Student != null)
                    return Student.LastName + " " + Student.FirstName;
                else
                    return "שם לא ידוע";
            }
        }

        public LessonModels() { }
        
    }
}
