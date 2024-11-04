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
        public LessonModels(Models.LessonModels modelLesson)
        {
            this.Id = modelLesson.Id;
            this.LessonDate = modelLesson.LessonDate;
            this.LessonTime = modelLesson.LessonTime;
            this.LessonType = modelLesson.LessonType;
            this.StudentId = modelLesson.StudentId;
            this.InstructorId = modelLesson.InstructorId;
            this.Comments = modelLesson.Comments;
        }

        public Models.LessonModels GetModels()
        {
            Models.LessonModels modelLesson = new Models.LessonModels()
            {
                Id = this.Id,
                LessonDate = this.LessonDate,
                LessonTime = this.LessonTime,
                LessonType = this.LessonType,
                StudentId = this.StudentId,
                InstructorId = this.InstructorId,
                Comments = this.Comments
            };

            return modelLesson;
        }
    }
}
