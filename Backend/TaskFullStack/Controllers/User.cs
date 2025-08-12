using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using App.Domain.DTOs;
using App.Service.ServUnitOfWork;
using App.Domain.Entities;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class User : ControllerBase
    {   
        IServUnitOfWork _servUnitOfWork;
        IMapper _mapper;
        public User(IServUnitOfWork servUnitOfWork, IMapper mapper) {
            _servUnitOfWork = servUnitOfWork;
            _mapper = mapper;
        }
        [HttpGet,Authorize]
        public async Task<IActionResult> UserDetails([FromQuery]string email)
        {
            user user = (await _servUnitOfWork.UserService.GetUserByEmailAsync(email));
            if (user == null) { 
                return NotFound(); }
            registrationDTO registrationDTO=_mapper.Map<registrationDTO>(user);
            return Ok(registrationDTO);
        }
    }
}
