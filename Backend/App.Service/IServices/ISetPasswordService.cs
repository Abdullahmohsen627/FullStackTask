using App.Domain.Entities;

namespace App.Service.IServices
{
    public interface ISetPasswordService
    {
        public Task SeTPasswordAsync(user user);
    }
}
