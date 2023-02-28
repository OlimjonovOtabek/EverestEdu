using EverestEdu.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EverestEduApplication.Abstractions
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Student> Students { get; set; }
        DbSet<Group> Groups { get; set; }
        DbSet<StudentGroup> StudentGroups { get; set; }
        DbSet<Lesson> Lessons { get; set; }
        DbSet<Attendance> Attendances { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
