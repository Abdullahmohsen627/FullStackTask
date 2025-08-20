using App.Domain.DTOs;
using App.Domain.Entities;
using App.Service.ServUnitOfWork;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        readonly IServUnitOfWork _servUnitOfWork;
        readonly IMapper _mapper;
        public RegistrationController(IServUnitOfWork servUnitOfWork, IMapper mapper)
        {
            _servUnitOfWork = servUnitOfWork;
            _mapper = mapper;
        }
        [HttpPost("UploadLogo")]
        public async Task<IActionResult> UploadLogo(IFormFile file)
        {
            //Extentions
            List<string> validExtentions = new List<string>() { ".jpg", ".png", ".gif" };
            string extension = Path.GetExtension(file.FileName);
            if (!validExtentions.Contains(extension))
            {
                return BadRequest("Invalid Extention");
            }
            long size = file.Length;
            if (size > (5 * 1024 * 1024))
                return BadRequest("maximum size can be 5MB");
            return Ok(_servUnitOfWork.FileService.UploadLogo(file));
        }
        [HttpPost, Route("GetNewOTP")]
        public async Task<IActionResult> SendMessage([FromBody]string email)
        {
            user user=await _servUnitOfWork.UserService.GetUserByEmailAsync(email);
            Random random = new Random();
            string OTP = random.Next(100000, 999999).ToString();
            await _servUnitOfWork.EmailService.SendEmailAsync(email, "OTP Validator", OTP);

            EmailOTP emailOTP = new EmailOTP()
            {
                Email = email,
                OTP = OTP,
                SendingTime = DateTime.Now,
            };
            await _servUnitOfWork.EmailOTPService.AddEmailOTPAsync(emailOTP);
            await _servUnitOfWork.SaveChangesAsync();
            return Ok(emailOTP);
        }
        [HttpPost]
        public async Task<IActionResult> Registration(registrationDTO registrationDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Model");
            }
            user? user = await _servUnitOfWork.UserService.GetUserByEmailAsync(registrationDTO.Email);
            if (user != null)
            {
                return BadRequest("This Email Already Exist");
            }
            Random random = new Random();
            string OTP = random.Next(100000, 999999).ToString();
            await _servUnitOfWork.EmailService.SendEmailAsync(registrationDTO.Email, "OTP Validator", OTP);

            EmailOTP emailOTP = new EmailOTP()
            {
                Email = registrationDTO.Email,
                OTP = OTP,
                SendingTime = DateTime.Now
            };
            await _servUnitOfWork.EmailOTPService.AddEmailOTPAsync(emailOTP);
            await _servUnitOfWork.SaveChangesAsync();
            return Ok(registrationDTO);
        }
        [HttpPost("setPassword")]
        public async Task<IActionResult> SetPassword(UserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid User Or Password");
            }
            user? userCheck =await _servUnitOfWork.UserService.GetUserByEmailAsync(userDTO.email);
            if (userCheck!=null)
            {
                return BadRequest();
            }
            user user = _mapper.Map<user>(userDTO);
            await _servUnitOfWork.SetPasswordService.SeTPasswordAsync(user);
            await _servUnitOfWork.UserService.AddUserAsync(user);
            await _servUnitOfWork.SaveChangesAsync();
            return Ok("user Created!");
        }
        [HttpPost("ValidateOTP")]
        public async Task<IActionResult> ValidateOTP([FromBody]EmailOTPDTO emailOTPDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("invalid OTP");
            }
            EmailOTP? emailOTP = await _servUnitOfWork.EmailOTPService.GetEmailOTPAsync(emailOTPDTO);
            if (emailOTP != null && emailOTP.SendingTime.AddMinutes(5) > DateTime.Now && emailOTP.IsValidated == false)
            {
                emailOTP.IsValidated = true;
                await _servUnitOfWork.EmailOTPService.UpdateEmailOTPAsync(emailOTP);
                await _servUnitOfWork.SaveChangesAsync();
                return Ok("Valide OTP");
            }
            return BadRequest("Invalid OTP");
        }
    }
}