using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TGE.Models.Responses;
using TGE.Models.User;
using TGE.Services.User;

namespace TGE.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestableApiController : ControllerBase
    {
        private readonly INewUserService _testable;

        public TestableApiController(INewUserService testable)
        {
            _testable = testable;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegister model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registerResult = await _testable.RegisterUserAsync(model);
            if (registerResult)
            {
                TextResponse response = new("User was registered");
                return Ok(response);
            }
            return BadRequest(new TextResponse("User could not be registered"));
        }
    }
}