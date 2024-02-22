using ShopifySharp.Shared.BaseModels;

namespace ShopifySharp.Product.Domain.Entities
{
    public class Products : BaseEntity
    {
        public Guid CategoryId { get; set; }
        public Categorys Category { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

    }
}
