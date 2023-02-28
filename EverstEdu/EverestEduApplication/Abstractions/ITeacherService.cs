using EverestEduApplication.Models;

namespace EverestEduApplication.Abstractions
{
    public interface ITeacherService
    {
        Task<TeacherViewModel> GetByIdAsync(int id);
        Task<List<TeacherViewModel>> GetAllAsync();
        Task CreateAsync(CreateTeacherModel Model);
        Task UpdateAsync(UpdateTeacherModel model);
        Task DeleteAsync(int id);
    }
}
