using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Span.Culturio.Auth.Services;
using Span.Culturio.Core.Models.Auth;
using Span.Culturio.Core.Models.Users;

namespace Span.Culturio.Auth.Controllers {
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase {
        private readonly IValidator<CreateUserDto> _validator;
        private readonly IAuthService _authService;

        public AuthController(IValidator<CreateUserDto> validator, IAuthService authService) {
            _validator = validator;
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> RegisterUser(CreateUserDto registerUserDto) {
            ValidationResult result = _validator.Validate(registerUserDto);
            if (!result.IsValid) return BadRequest("ValidationError");

            var user = await _authService.RegisterUser(registerUserDto);
            if (user is null) return BadRequest();

            return Ok("Successful response");
        }

        [HttpPost("login")]
        public async Task<ActionResult<TokenDto>> Login(LoginDto loginUserDto) {
            var token = await _authService.Login(loginUserDto);
            if (token is null) return BadRequest("Bad username or password");

            return Ok(token);
        }

    }
}
