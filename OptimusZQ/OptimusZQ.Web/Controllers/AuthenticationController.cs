using Microsoft.AspNetCore.Mvc;
using OptimusZQ.Services.Abstract;
using OptimusZQ.Services.Dtos;

namespace OptimusZQ.Web.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        IAuthenticationService _authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost, Route("login")]
        public IActionResult Login([FromBody]LoginModel user)
        {
            if (user == null)
            {
                return BadRequest("Invalid client request");
            }

            if(_authenticationService.HasUser(user.UserName))
            {
                var token = _authenticationService.LogIn(user.UserName, user.Password);

                if(token != null)
                {
                    return Ok(new { Token = token });
                }

            }

            return Unauthorized();
        }

    }
}