using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopifySharp.Identity.Application.Commands.Users.Create;
using ShopifySharp.Identity.Application.Queries.Login;

namespace ShopifySharp.Identity.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginQueries request)
        {
            try
            {
                var token = await _mediator.Send(request);
                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(CreateUserCommand request)
        {
            try
            {
                var token = await _mediator.Send(request);
                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
