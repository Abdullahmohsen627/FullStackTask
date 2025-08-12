using App.Domain.Entities;
namespace App.Service.IServices
{
    public interface IAuthenticationService
    {
        public string GenerateAccessToken(user user);
    }
}
