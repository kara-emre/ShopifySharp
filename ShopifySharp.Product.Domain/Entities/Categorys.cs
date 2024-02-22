using ShopifySharp.Shared.BaseModels;

namespace ShopifySharp.Product.Domain.Entities
{
    public class Categorys : BaseEntity
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
    }
}
