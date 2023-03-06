namespace EverestEduApplication.Models
{
    public class CreateGroupModel
    {
        public string? Name { get; set; }
        public int TeacherId { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public TimeSpan LessonStartTime { get; set; }
        public TimeSpan LessonEndTime { get; set; }
    }
}
