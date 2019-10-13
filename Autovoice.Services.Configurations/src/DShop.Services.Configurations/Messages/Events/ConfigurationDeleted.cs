using System;
using Autovoice.Common.Messages;
using Newtonsoft.Json;

namespace Autovoice.Services.Configurations.Messages.Events
{
    public class ConfigurationDeleted : IEvent
    {
        public Guid Id { get; }

        [JsonConstructor]
        public ConfigurationDeleted(Guid id)
        {
            Id = id;
        }
    }
}
