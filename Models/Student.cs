using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class Student
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 char")]
        [Column("FirstName")]
        [DisplayName("First Mid Name")]
        public string FirstMidName { get; set; } = string.Empty;

        [DisplayName("Enrollment Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        public DateTime EnrollmentDate { get; set; }

        [DisplayName("Full Name")]
        public string FullName { get { return LastName + ", " + FirstMidName; } }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
