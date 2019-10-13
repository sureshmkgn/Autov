using Autovoice.Common.Types;
using System;

namespace Autovoice.Services.Products.Domain
{
    public class Product : BaseEntity 
        {
       // public string Name { get; private set; }
      

        public Product(Guid id, string name) : base(id,name)
        {
            SetName(name);
           
        }

        public void SetName(string name)
        {
            if(string.IsNullOrEmpty(name))
            {
                throw new DShopException("empty_product_name", 
                    "Product name cannot be empty.");
            }

            Name = name.Trim().ToLowerInvariant();
            SetUpdatedDate();
        }
            
    }
}