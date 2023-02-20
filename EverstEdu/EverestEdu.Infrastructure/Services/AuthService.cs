using EverestEdu.Infrastructure.Abstractions;
using EverestEdu.Infrastructure.Persistence;
using EverestEdu.Infrastructure.Utils;
using Microsoft.EntityFrameworkCore;

namespace EverestEdu.Infrastructure.Services
{
    internal class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ITokenService _tokenService;

        public AuthService(ApplicationDbContext dbContext, ITokenService tokenService)
        {
            _dbContext = dbContext;
            _tokenService = tokenService;
        }

        public async Task<string> LoginAsync(string username, string password)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.UserName == username);

            if (user is null)
            {
                throw new Exception("User not found");
            }
            if (user.PasswordHash != HashGenerater.Generate(password))
            {
                throw new Exception("Password or Login is wrong ");
            }


            return _tokenService.GenerateAccesToken(user);
        }
    }
}
