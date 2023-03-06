using EverestEdu.Domain.Entities;
using EverestEduApplication.Abstractions;
using EverestEduApplication.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace EverestEduApplication.Services
{
    public class GroupService : IGroupService
    {
        private readonly IApplicationDbContext _context;

        public GroupService(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(CreateGroupModel model)
        {
            var entity = new Group()
            {
                Name = model.Name,
                TeacherId = model.TeacherId,
                StartDate = model.StartDate.ToDateTime(TimeOnly.MinValue),
                EndDate = model.EndDate.ToDateTime(TimeOnly.MaxValue),
            };

            await _context.Groups.AddAsync(entity);

            var lessons = CreateLessons(entity, model.LessonStartTime, model.LessonEndTime);

            _context.Lessons.AddRange(lessons);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Groups.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                throw new Exception("Not Found");
            }

            _context.Groups.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<GroupViewModel>> GetAllAsync()
        {

            return await _context.Groups
               .Select(x => new GroupViewModel()
               {
                   Id = x.Id,
                   Name = x.Name,
                   StartDate = x.StartDate,
                   TeacherId = x.TeacherId,
                   EndDate = x.EndDate,
               })
               .ToListAsync();
        }

        public async Task<GroupViewModel> GetByIdAsync(int id)
        {
            var entity = await _context.Groups.FirstOrDefaultAsync(x => x.Id == id);

            return new GroupViewModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                TeacherId = entity.TeacherId,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
            };
        }

        public async Task UpdateAsync(UpdateGroupModel model)
        {
            var entity = await _context.Groups.Include(x => x.Lessons).FirstOrDefaultAsync(x => x.Id == model.Id);

            if (entity == null)
            {
                throw new Exception("Not found");
            }

            entity.Name = model.Name ?? entity.Name;
            entity.TeacherId = model.TeacherId ?? entity.TeacherId;

            _context.Groups.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task AddStudentAsync(AddStudentGroupModel model, int groupId)
        {

            if (await _context.Groups.AnyAsync(x => x.Id == model.StudentId))
            {
                throw new Exception("Student Not Found");
            }

            if (!await _context.Groups.AnyAsync(x => x.Id == groupId))
            {
                throw new Exception("Group Not Found");
            }

            var studetnInGroup = new StudentGroup()
            {
                GroupId = groupId,
                StudentId = model.StudentId,
                IsPayed = model.IsPayed,
                JoinedDate = model.JoinedDate,
            };

            await _context.StudentGroups.AddAsync(studetnInGroup);
            await _context.SaveChangesAsync();
        }
        public async Task RemoveStudentAsync(int studentId, int groupId)
        {
            var entity = await
                _context.StudentGroups.FirstOrDefaultAsync(x => x.GroupId == groupId && x.StudentId == studentId);

            if (entity is null)
            {
                throw new Exception("Student Not Found");
            }

            _context.StudentGroups.Remove(entity);
            await _context.SaveChangesAsync();
        }

        private List<Lesson> CreateLessons(Group entity, TimeSpan lessonStartTime, TimeSpan lessonEndTime)
        {
            var lessons = new List<Lesson>();

            var totalDayFromStartToEnd = (entity.EndDate - entity.StartDate).Days;

            var currentDate = entity.StartDate;
            for (int i = 1; i <= totalDayFromStartToEnd; i++)
            {
                if (currentDate.DayOfWeek != DayOfWeek.Sunday && currentDate.DayOfWeek != DayOfWeek.Saturday)
                {
                    var lesson = new Lesson()
                    {
                        Group = entity,
                        StartDateTime = currentDate.Date + lessonStartTime,
                        EndDateTime = currentDate.Date + lessonEndTime,
                    };
                    lessons.Add(lesson);
                }
                currentDate.AddDays(1);
            }

            return lessons;
        }

    }
}
