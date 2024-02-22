using MediatR;

namespace ShopifySharp.Identity.Application.Queries.Login
{
    public class LoginQueries : IRequest<string>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
