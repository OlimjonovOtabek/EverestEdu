using EverestEduApplication.Models;

namespace EverestEduApplication.Abstractions
{
    public interface IGroupService : ICrudService<int, GroupViewModel, CreateGroupModel, UpdateGroupModel>
    {
        Task AddStudentAsync(AddStudentGroupModel model, int groupId);
        Task RemoveStudentAsync(int studentId, int groupId);
    }
}
