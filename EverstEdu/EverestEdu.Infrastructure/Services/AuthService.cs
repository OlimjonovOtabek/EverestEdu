using EverestEdu.Infrastructure.Abstractions;
using EverestEdu.Infrastructure.Persistence;
using EverestEduApplication.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace EverestEdu.Infrastructure.Services
{
    internal class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ITokenService _tokenService;
        private readonly IHashProvider _hashProvider;

        public AuthService(ApplicationDbContext dbContext, ITokenService tokenService, IHashProvider hashProvider)
        {
            _dbContext = dbContext;
            _tokenService = tokenService;
            _hashProvider = hashProvider;
        }

        public async Task<string> LoginAsync(string username, string password)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.UserName == username);

            if (user is null)
            {
                throw new Exception("User not found");
            }
            if (user.PasswordHash != _hashProvider.GetHash(password))
            {
                throw new Exception("Password or Login is wrong ");
            }


            return _tokenService.GenerateAccesToken(user);
        }
    }
}
