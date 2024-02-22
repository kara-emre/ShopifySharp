using Microsoft.AspNetCore.Identity;

namespace ShopifySharp.Identity.Domain.Entities
{
    public class User : IdentityUser
    {
        /// <summary>
        /// 
        /// </summary>
        public string? FullName { get; set; }
        /// <summary>  
        /// 
        /// </summary>
        public DateTime RegistrationDate { get; set; }
    }
}
