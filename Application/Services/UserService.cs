using Domain.Common.Interfaces;
using Domain.Entities;

namespace Application.Services
{
    public class UserService
    {
        private readonly IRepository<User> _repository;
        private readonly IPasswordHasher _passwordHasher;

        public UserService(IRepository<User> repository, IPasswordHasher passwordHasher)
        {
            _repository = repository;
            _passwordHasher = passwordHasher;
        }

        public async Task<User> AuthenticateAsync(string username, string password)
        {
            var user = await _repository.GetSingleAsync(n => n.UserName == username);

            _ = user ?? throw new UnauthorizedAccessException(Message.InvalidCredentials);

            if(!VerifyPassword(password, user.password))
            {
                throw new UnauthorizedAccessException(Message.InvalidCredentials);
            }
            return user;
        }
        private bool VerifyPassword(string password, byte[]  hasehdPassword)
        {
           return _passwordHasher.VerifyPassword(hasehdPassword, password);
        }
    }
}
