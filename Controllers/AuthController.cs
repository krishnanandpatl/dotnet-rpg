using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_rpg.Data;
using dotnet_rpg.Dtos.User;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_rpg.Controllers
{
    [ApiController]
    [Route("[controller]")] //name of the route is defined by whatever written before of Controller in this case auth.
    public class AuthController: ControllerBase
    {
        private readonly IAuthRepository _authoRepo;

        public AuthController(IAuthRepository authoRepo)
        {
            _authoRepo = authoRepo;
        }
        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegisterDto request)
        {
            var response= await _authoRepo.Register(
                new User {Name=request.Name},request.Password
            );
            if(!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(LoginDto request)
        {
            var response=await _authoRepo.Login(
                request.Name,request.password
            );
            if(!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}