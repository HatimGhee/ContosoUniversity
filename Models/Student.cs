using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Models
{
    public class Student
    {
        public int ID { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; } = string.Empty;

        [DisplayName("First Mid Name")]
        public string FirstMidName { get; set; } = string.Empty;

        [DisplayName("Enrollment Date")]
        [DataType(DataType.DateTime)]
        public DateTime EnrollmentDate { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
