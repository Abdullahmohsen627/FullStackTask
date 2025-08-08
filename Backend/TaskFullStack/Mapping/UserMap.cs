using AutoMapper;
using TaskFullStack.DTOs;
using TaskFullStack.Models;

namespace TaskFullStack.Mapping
{
    public class UserMap:Profile
    {
        public UserMap() {
            CreateMap<UserDTO, user>();
            CreateMap<user, registrationDTO>();
        }
    }
}
