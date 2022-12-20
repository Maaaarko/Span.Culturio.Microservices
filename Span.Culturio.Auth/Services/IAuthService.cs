using Span.Culturio.Core.Models.Users;
using Span.Culturio.Core.Models.Auth;

namespace Span.Culturio.Auth.Services {
    public interface IAuthService {
        Task<UserDto> RegisterUser(CreateUserDto registerUserDto);
        Task<TokenDto> Login(LoginDto loginUserDto);
    }
}
