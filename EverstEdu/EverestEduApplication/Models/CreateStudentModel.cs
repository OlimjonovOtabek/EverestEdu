using System.ComponentModel.DataAnnotations;

namespace EverestEduApplication.Models
{
    public class CreateStudentModel
    {

        [Required]
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}
