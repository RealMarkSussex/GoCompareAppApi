﻿using GoCompareAppApi.Models.Requests;
using GoCompareAppApi.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace GoCompareAppApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        [HttpPost(Name = "Login")]
        public async Task<LoginResponseData> Login(LoginRequestData loginRequestData)
        {
            return await Task.Run(() => new LoginResponseData { Successful = true });
        }
    }
}
