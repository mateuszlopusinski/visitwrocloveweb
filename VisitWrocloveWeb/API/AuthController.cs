using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VisitWrocloveWeb.Auth.Exceptions;
using VisitWrocloveWeb.Auth.Interfaces;
using VisitWrocloveWeb.Auth.Models;
using VisitWrocloveWeb.Auth.ViewModels;

namespace VisitWrocloveWeb.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService) : base()
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("token")]
        [ProducesResponseType(typeof(JsonWebToken), 200)]
        public async Task<IActionResult> LoginAsync([FromBody] LoginByCredentialsViewModel loginByCredentials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var token = await _authService.LoginByCredentialsAsync(loginByCredentials.Email,
                    loginByCredentials.Password);

                return Ok(token);
            }
            catch (UnauthorizedException)
            {
                return Unauthorized();
            }
        }

        //[AllowAnonymous]
        //[HttpPost("refresh_token")]
        //[ProducesResponseType(typeof(JsonWebToken), 200)]
        //public async Task<IActionResult> RefreshTokenAsync([FromBody] LoginByRefreshTokenViewModel loginByRefreshToken)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    try
        //    {
        //        var token = await _authService.LoginByRefreshToken(loginByRefreshToken.RefreshToken, loginByRefreshToken.UserId);

        //        return Ok(token);
        //    }
        //    catch (UnauthorizedException)
        //    {
        //        return Unauthorized();
        //    }
        //}

        //[HttpPut("{userId}")]
        //[ProducesResponseType(200)]
        //public async Task<IActionResult> ChangePasswordAsync([FromRoute] int userId,
        //    [FromBody] ChangePasswordViewModel changePasswordViewModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (!IsUserAuthorizedToPerformCommand(userId))
        //    {
        //        return BadRequest();
        //    }

        //    try
        //    {
        //        await _authService.ChangePassword(userId, changePasswordViewModel.OldPassword,
        //            changePasswordViewModel.NewPassword);

        //        return Ok();
        //    }
        //    catch (UnauthorizedException)
        //    {
        //        return Unauthorized();
        //    }
        //}
    }
}