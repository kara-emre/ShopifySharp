using MediatR;
using Microsoft.AspNetCore.Identity;
using ShopifySharp.Identity.Application.Services;
using ShopifySharp.Identity.Domain.Entities;

namespace ShopifySharp.Identity.Application.Queries.Login.Handlers
{
    public class LoginQueriesHandler : IRequestHandler<LoginQueries, string>
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;

        public LoginQueriesHandler(ITokenService tokenService, UserManager<User> userManager)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<string> Handle(LoginQueries command, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(command.Username);
            if (user == null || !await _userManager.CheckPasswordAsync(user, command.Password))
            {
                throw new Exception("Invalid username or password");
            }

            return _tokenService.GenerateToken(user);
        }
    }
}
