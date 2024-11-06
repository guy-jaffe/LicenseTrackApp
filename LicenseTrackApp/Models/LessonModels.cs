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
        public int? InstructorId { get; set; }
        public string? Comments { get; set; }

        public LessonModels() { }
        
    }
}
