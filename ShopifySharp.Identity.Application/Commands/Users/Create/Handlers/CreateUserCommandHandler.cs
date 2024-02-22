using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ShopifySharp.Identity.Application.Services;
using ShopifySharp.Identity.Domain.Entities;

namespace ShopifySharp.Identity.Application.Commands.Users.Create.Handlers
{
    internal class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(UserManager<User> userManager, ITokenService tokenService, IMapper mapper)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _mapper = mapper;
        }



        public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);

            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                return _tokenService.GenerateToken(user);
            }
            else
                throw new Exception(result.Errors.Select(x => x.Description).First());
        }
    }
}
