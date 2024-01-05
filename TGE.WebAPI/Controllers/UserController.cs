using Microsoft.AspNetCore.Mvc;
using TGE.Models.Responses;
using TGE.Models.User;
using TGE.Services.User;

namespace TGE.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly INewUserService _userService;
        public UserController(INewUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegister model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registerResult = await _userService.RegisterUserAsync(model);
            if (registerResult)
            {
                TextResponse response = new("User was registered");
                return Ok(response);
            }
            return BadRequest(new TextResponse("User could not be registered"));
        }

        // [HttpGet("{userId:int}")]
        // public async Task<IActionResult> GetById([FromRoute] int userId)
        // {
        //     UserDetail? detail = await _userService.GetUserByIdAsync(userId);
        //     if (detail is null)
        //     {
        //         return NotFound();
        //     }
        //     return Ok(detail);
        // }
    }
}
