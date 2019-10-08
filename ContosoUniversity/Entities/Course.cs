using System.Collections.Generic;

namespace ContosoUniversity.Entities
{
    public class Course
    {
        public Course()
        {
            Enrollments = new List<Enrollment>();
        }

        public int CourseId { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}