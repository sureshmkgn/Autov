using System;
using Autovoice.Common.Messages;
using Newtonsoft.Json;

namespace Autovoice.Services.Configurations.Messages.Events
{
    public class ConfigurationCreated : IEvent
    {
        public Guid Id { get; }
        public string Name { get; }
     

        [JsonConstructor]
        public ConfigurationCreated(Guid id, string name)
        {
            Id = id;
            Name = name;
            
        }
    }
}
