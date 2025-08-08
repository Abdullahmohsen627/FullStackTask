using TaskFullStack.Models;

namespace TaskFullStack.IServices
{
    public interface IAuthenticationService
    {
        public string GenerateAccessToken(user user);
    }
}
