using EverestEduApplication.Models;

namespace EverestEduApplication.Abstractions
{
    public interface ITeacherService : ICrudService<int, TeacherViewModel, CreateTeacherModel, UpdateTeacherModel>
    {
    }
}
