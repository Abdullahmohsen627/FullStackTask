using TaskFullStack.DTOs;
using TaskFullStack.Models;

namespace TaskFullStack.IServices
{
    public interface ISetPasswordService
    {
        public Task SeTPasswordAsync(user user);
    }
}
