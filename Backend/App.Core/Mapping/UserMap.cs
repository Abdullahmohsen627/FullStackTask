using App.Domain.DTOs;
using App.Domain.Entities;
using AutoMapper;

namespace App.Core.Mapping
{
    public class UserMap:Profile
    {
        public UserMap() {
            CreateMap<UserDTO, user>();
            CreateMap<user, registrationDTO>();
        }
    }
}
