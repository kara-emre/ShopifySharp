using MediatR;

namespace ShopifySharp.Identity.Application.Commands.Users.Create
{
    public class CreateUserCommand : IRequest<string>
    {
        public string Username { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }

        public CreateUserCommand(string username, string email)
        {
            Username = username;
            Email = email;
            // Diğer kullanıcı bilgilerini değişkenlere atama...
        }
    }
}
