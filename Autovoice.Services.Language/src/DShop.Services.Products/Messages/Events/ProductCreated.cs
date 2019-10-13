using System;
using Autovoice.Common.Messages;
using Newtonsoft.Json;

namespace Autovoice.Services.Products.Messages.Events
{
    public class ProductCreated : IEvent
    {
        public Guid Id { get; }
        public string Name { get; }
     

        [JsonConstructor]
        public ProductCreated(Guid id, string name)
        {
            Id = id;
            Name = name;
            
        }
    }
}
