using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Models
{
    public class StudentVM
    {
        public int ID { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("First Mid Name")]
        public string FirstMidName  { get; set; }

        [DisplayName("Enrollment Date")]
        [DataType(DataType.DateTime)]
        public DateTime EnrollmentDate  { get; set; }
    }
}
