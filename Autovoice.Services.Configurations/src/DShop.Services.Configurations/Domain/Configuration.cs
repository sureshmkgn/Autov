using Autovoice.Common.Types;
using System;

namespace Autovoice.Services.Configurations.Domain
{
    public class Configuration : BaseEntity 
        {

        public string Value { get; set; }
        public Configuration(Guid id, string key,string value) : base(id,key)
        {
            SetConfigurationKey(key);
            SetConfigurationValue(value);
        }

        public void SetConfigurationKey(string key)
        {
            if(string.IsNullOrEmpty(key))
            {
                throw new DShopException("empty_product_name", 
                    "Product name cannot be empty.");
            }

            Name = key.Trim().ToLowerInvariant();
            SetUpdatedDate();
        }

        public void SetConfigurationValue(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new DShopException("empty_product_name",
                    "Product name cannot be empty.");
            }

            Name = value.Trim().ToLowerInvariant();
            SetUpdatedDate();
        }

    }
}