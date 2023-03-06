namespace EverestEdu.Domain.Entities
{
    public class Group
    {
        public Group()
        {
            Lessons = new HashSet<Lesson>();
            GroupStudents = new HashSet<StudentGroup>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int TeacherId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public User? Teacher { get; set; }
        public ICollection<Lesson> Lessons { get; set; }
        public ICollection<StudentGroup> GroupStudents { get; set; }
    }
}
