using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Models
{
    public class OfficeAssignment
    {
        public int ID { get; set; }

        [StringLength(50), DisplayName("Office Location")]
        public string Location { get; set; }
        public Instructor Instructor { get; set; }
    }
}