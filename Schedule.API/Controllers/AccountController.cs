using Microsoft.AspNetCore.Mvc;
using Schedule.BackgroundJob.Schedules;
using Schedule.Business.Abstract;
using Schedule.Entities.Dtos.Account;
using System;
using System.Threading.Tasks;

namespace Schedule.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Register")]
        [Obsolete]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            var user = await _authService.Register(userForRegisterDto);

            DelayedJobs.SendMailRegisterJobs(user.Id);

            return Ok(user);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var user = await _authService.Login(userForLoginDto).ConfigureAwait(false);

            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> UserRegisterCheck([FromQuery] string returnUrl)
        {
            if (string.IsNullOrWhiteSpace(returnUrl))
                return BadRequest("Yönlendirme URL'i boş !");

            var response = await _authService.UserActivatedRegister(returnUrl);
            return response ? Ok("Kullanıcı Email adresi doğrulama işlemi başarılı !") : BadRequest("Kullanıcı bulunamadı!");
        }
    }
}