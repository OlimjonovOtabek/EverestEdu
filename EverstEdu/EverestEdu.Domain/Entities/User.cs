using EverestEdu.Domain.Enums;

namespace EverestEdu.Domain.Entities
{
    public class User
    {
        public User()
        {
            Groups = new HashSet<Group>();
        }
        public int Id { get; set; }
        public string PasswordHash { get; set; }
        public string? FullName { get; set; }
        public string? UserName { get; set; }
        public UserRole Role { get; set; }

        public ICollection<Group> Groups { get; set; }
    }
}
