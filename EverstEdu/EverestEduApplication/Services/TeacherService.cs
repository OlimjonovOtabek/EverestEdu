using EverestEdu.Domain.Entities;
using EverestEdu.Domain.Enums;
using EverestEduApplication.Abstractions;
using EverestEduApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace EverestEduApplication.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly IApplicationDbContext _context;
        private readonly IHashProvider _hashProvider;
        public TeacherService(IApplicationDbContext context, IHashProvider hashProvider)
        {
            _context = context;
            _hashProvider = hashProvider;
        }

        public async Task CreateAsync(CreateTeacherModel model)
        {
            var entity = new User()
            {
                FullName = model.FullName,
                UserName = model.UserName,
                PasswordHash = _hashProvider.GetHash(model.Password),
                Role = UserRole.Teacher
            };

            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Users.FirstOrDefaultAsync(x => x.Id == id && x.Role == UserRole.Teacher);

            if (entity is null)
            {
                throw new Exception("Not found");
            }

            _context.Users.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<TeacherViewModel>> GetAllAsync()
        {
            return await _context.Users.Where(x => x.Role == UserRole.Teacher)
                .Select(x => new TeacherViewModel()
                {
                    Id = x.Id,
                    UserName = x.UserName,
                    FullName = x.FullName
                })
                .ToListAsync();
        }

        public async Task<TeacherViewModel> GetByIdAsync(int id)
        {
            var entity = await _context.Users.FirstOrDefaultAsync(x => x.Id == id && x.Role == UserRole.Teacher);

            return new TeacherViewModel()
            {
                Id = entity.Id,
                UserName = entity.UserName,
                FullName = entity.FullName
            };
        }

        public async Task UpdateAsync(UpdateTeacherModel model)
        {
            var entity = await _context.Users.FirstOrDefaultAsync(x => x.Id == model.Id && x.Role == UserRole.Teacher);

            if (entity is null)
            {
                throw new Exception("Not found");
            }
            entity.UserName = model.UserName ?? entity.UserName;
            entity.FullName = model.FullName ?? entity.FullName;
            entity.PasswordHash = model.Password == null ? entity.PasswordHash : _hashProvider.GetHash(model.Password);

            _context.Users.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
