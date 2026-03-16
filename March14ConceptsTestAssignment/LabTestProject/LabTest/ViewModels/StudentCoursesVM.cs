using LabTest.Models;

namespace LabTest.ViewModels
{
    public class StudentCoursesVM
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string Branch { get; set; }

        public string CourseTitle { get; set; }
        public string Grade { get; set; }
        public int AttemptNumber { get; set; }
    }
}
