using Microsoft.AspNetCore.Mvc;
using OptimusZQ.Services.Abstract;
using OptimusZQ.Services.Dtos;

namespace OptimusZQ.Web.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController : Controller
    {

        IAuthenticationService _authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("[action]")]
        public IActionResult Login([FromBody]LoginModel user)
        {
            if (user == null)
            {
                return BadRequest("Invalid client request");
            }

            if(_authenticationService.HasUser(user.Login))
            {
                var token = _authenticationService.LogIn(user.Login, user.Password);
                var curentUser = _authenticationService.GetUserByUserLogin(user.Login);

                if(token != null)
                {
                    return Ok(new { Token = token , User = curentUser });
                }

            }

            return Unauthorized();
        }

        [HttpGet("[action]")]
        public IActionResult Test()
        {
            return Ok();
        }

    }
}

