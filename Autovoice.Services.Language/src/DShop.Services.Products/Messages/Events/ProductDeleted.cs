using System;
using Autovoice.Common.Messages;
using Newtonsoft.Json;

namespace Autovoice.Services.Products.Messages.Events
{
    public class ProductDeleted : IEvent
    {
        public Guid Id { get; }

        [JsonConstructor]
        public ProductDeleted(Guid id)
        {
            Id = id;
        }
    }
}
