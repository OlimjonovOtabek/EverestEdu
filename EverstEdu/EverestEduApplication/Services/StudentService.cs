using EverestEdu.Domain.Entities;
using EverestEduApplication.Abstractions;
using EverestEduApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace EverestEduApplication.Services
{
    public class StudentService: IStudentService
    {
        private readonly IApplicationDbContext _context;

        public StudentService(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(CreateStudentModel model)
        {
            var entity = new Student()
            {
                FullName = model.FullName,
                BirthDate = model.BirthDate,
                PhoneNumber = model.PhoneNumber,
                CreatedDateTime = DateTime.UtcNow,

            };
            await _context.Students.AddAsync(entity);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);

            if (entity is null)
            {
                throw new Exception("Not found");
            }

            _context.Students.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<StudentViewModel>> GetAllAsync()
        {
            return await _context.Students
                .Select(x => new StudentViewModel()
                {
                    Id = x.Id,
                    FullName = x.FullName,
                    BirthDate = x.BirthDate,
                    PhoneNumber = x.PhoneNumber
                })
                .ToListAsync();
        }

        public async Task<StudentViewModel> GetByIdAsync(int id)
        {
            var entity = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);

            return new StudentViewModel()
            {
                Id = entity.Id,
                FullName = entity.FullName,
                BirthDate = entity.BirthDate,
                PhoneNumber = entity.PhoneNumber
            };
        }

        public async Task UpdateAsync(UpdateStudentModel model)
        {
            var entity = await _context.Students.FirstOrDefaultAsync(x => x.Id == model.Id);

            if (entity is null)
            {
                throw new Exception("Not found");
            }
            entity.FullName = model.FullName ?? entity.FullName;
            entity.BirthDate = model.BirthDate ?? entity.BirthDate;
            entity.PhoneNumber = model.PhoneNumber ?? entity.PhoneNumber;

            _context.Students.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}

