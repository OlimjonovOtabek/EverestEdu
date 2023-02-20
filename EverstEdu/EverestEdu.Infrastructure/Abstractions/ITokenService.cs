using EverestEdu.Domain.Entities;

namespace EverestEdu.Infrastructure.Abstractions
{
    public interface ITokenService
    {
        string GenerateAccesToken(User user);
    }
}
