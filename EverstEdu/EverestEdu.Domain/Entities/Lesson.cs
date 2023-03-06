namespace EverestEdu.Domain.Entities
{
    public class Lesson
    {
        public Lesson()
        {
            Attendances = new HashSet<Attendance>();
        }
        public int Id { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int GroupId { get; set; }

        public Group? Group { get; set; }
        public ICollection<Attendance> Attendances { get; set; }

    }
}
