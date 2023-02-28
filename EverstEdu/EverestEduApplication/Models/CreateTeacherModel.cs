using System.ComponentModel.DataAnnotations;

namespace EverestEduApplication.Models
{
    public class CreateTeacherModel
    {
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string FullName { get; set; }
        

    }
}
