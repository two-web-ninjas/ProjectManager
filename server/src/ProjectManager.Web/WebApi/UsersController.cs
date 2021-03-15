using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ProjectManager.Core.Entity;
using ProjectManager.Core.Factories;
using ProjectManager.Core.Lib;
using ProjectManager.Core.RepositoryInterface;
using ProjectManager.Infrastructure;
using ProjectManager.Infrastructure.Data;
using ProjectManager.Web.Identities;
using ProjectManager.Web.WebApiModels;

namespace ProjectManager.Web.WebApi
{
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtProvider _jwtProvider;
        
        private readonly DynamicTypeFactory _dynamicTypeFactory;
        private readonly SignInManager<User> _signInManager;

        public UsersController(IUnitOfWork unitOfWork,
                               IJwtProvider jwtProvider,
                               DynamicTypeFactory dynamicTypeFactory,
                               SignInManager<User> signInManager)
        {
            _unitOfWork = unitOfWork;
            _jwtProvider = jwtProvider;
            _dynamicTypeFactory = dynamicTypeFactory;
            _signInManager = signInManager;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Registration([FromBody]UserDto request)
        {
            var response = new ApiResponse();

            if (!ModelState.IsValid)
            {
                response.Errors = ModelState.GetErrors(_dynamicTypeFactory);
                return BadRequest(response);
            }

            var newUser = new User
            {
                Email = request.Email,
                UserName = request.UserName,
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateOfBirth = DateTime.Parse(request.DateOfBirth?.ToString("yyyy-MM-dd"))
            };

            var result = await _signInManager.UserManager.CreateAsync(newUser, request.Password);
            if (result.Succeeded)
            {
                // TODO email confirmation 
            }

            response.Message = ResponseCodes.REGISTER_SUCCESS;
            return Ok(response);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginDto request)
        {
            var response = new ApiResponse();
            var errorDict = new Dictionary<string, List<string>>();

            if (!ModelState.IsValid)
            {
                response.Errors = ModelState.GetErrors(_dynamicTypeFactory);
                return BadRequest(response);
            }

            var user = _unitOfWork.Users.GetFirstOrDefault(u => u.Email == request.UserNameOrEmail || u.UserName == request.UserNameOrEmail);
            if(user == null || request.Password == null)
            {   
                errorDict.Add(nameof(user), new List<string>() { ResponseCodes.INVALID_USERNAME_OR_PASSWORD });
                response.Errors = errorDict.GetModelError(_dynamicTypeFactory);
                return BadRequest(response);
            }

            var result = _signInManager.PasswordSignInAsync(user, request.Password, false, false).Result;
            if (result.IsLockedOut)
            {
                errorDict.Add(nameof(request.UserNameOrEmail), new List<string>() { ResponseCodes.LOCK_OUT + user.LockoutEnd?.ToLocalTime().ToString("dd/MM/yyyy H:mm:ss zzz") });
                response.Errors = errorDict.GetModelError(_dynamicTypeFactory);
                return BadRequest(response);
            }
            else if (!result.Succeeded)
            {
                await _signInManager.UserManager.AccessFailedAsync(user);

                errorDict.Add(nameof(request.UserNameOrEmail), new List<string>() { ResponseCodes.INVALID_USERNAME_OR_PASSWORD });
                response.Errors = errorDict.GetModelError(_dynamicTypeFactory);
                return BadRequest(response);
            }

            response.Data = _jwtProvider.GetJwtToken(user);
            return Ok(response);
        }
    }
}
