﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Account;
using Service.Services.Interfaces;

namespace App.Controllers.UI
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
            
        }
        [HttpPost]
        public async Task <IActionResult> SignUp([FromBody] RegisterDto request)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState); 
            var response= await _accountService.SignUp(request);
            if (!response.Success)
            {
                return BadRequest(response);

            }
            return Ok(response);
        }

        [HttpGet]

        public async Task<IActionResult> GetAllUsers()
        {
            return Ok( await _accountService.GetUsersAsync());
        }

        [HttpGet]

        public async Task<IActionResult> GetUserByUSerName([FromQuery]string userName)
        {
            return Ok(await _accountService.GetUserByUsernameAsync(userName));
        }
    }
}
