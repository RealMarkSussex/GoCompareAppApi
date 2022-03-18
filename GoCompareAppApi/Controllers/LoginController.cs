using Domain.Interfaces;
using GoCompareAppApi.Models.Requests;
using GoCompareAppApi.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace GoCompareAppApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService loginService;

        public LoginController(ILoginService loginService)
        {
            this.loginService = loginService;
        }

        [HttpPost(Name = "Login")]
        public async Task<LoginResponseData> Login(LoginRequestData loginRequestData)
        {
            var successful = loginService.Login(loginRequestData.Email, loginRequestData.Password);
            return new LoginResponseData() { Successful = successful };
        }
    }
}
