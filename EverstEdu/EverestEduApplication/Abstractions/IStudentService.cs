using EverestEduApplication.Models;

namespace EverestEduApplication.Abstractions
{
    public interface IStudentService : ICrudService<int, StudentViewModel, CreateStudentModel, UpdateStudentModel>
    {
    }
}
