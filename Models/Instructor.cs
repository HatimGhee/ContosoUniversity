using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class Instructor
    {
        public int ID { get; set; }

        [Required, DisplayName("Last Name"), StringLength(50)]
        public string LastName { get; set; }

        [Required, Column("FirstName"), DisplayName("First Name"), StringLength(50)]
        public string FirstMidName { get; set; }

        [DataType(DataType.Date), DisplayName("Hire Date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime HireDate { get; set; }

        [DisplayName("Full Name")]
        public string FullName { get { return LastName + ", " + FirstMidName; } }

        public ICollection<Course> Courses { get; set; }
        public OfficeAssignment OfficeAssignment { get; set; }
    }
}
