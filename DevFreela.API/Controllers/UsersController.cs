using DevFreela.API.Models;
using DevFreela.Application.Commands.CreateUser;
using DevFreela.Application.Commands.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{

    [Route("api/users")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        //api/users/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok();
        }
        //api/users
        [HttpPost]
        [AllowAnonymous]

        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtRoute(nameof(GetById), new { id = id }, command);
        }
        //api/users/1/login
        [HttpPut("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            var loginUserViewModel = await _mediator.Send(command);

            if(loginUserViewModel == null)
            {
                return BadRequest();
            }
            return Ok(loginUserViewModel);
        }



    }

}
