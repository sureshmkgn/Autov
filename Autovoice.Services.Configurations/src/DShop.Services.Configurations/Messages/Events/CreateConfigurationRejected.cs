using System;
using Autovoice.Common.Messages;
using Newtonsoft.Json;

namespace Autovoice.Services.Configurations.Messages.Events
{
    public class CreateConfigurationRejected : IRejectedEvent
    {
        public Guid Id { get; }
        public string Reason { get; }
        public string Code { get; }

        [JsonConstructor]
        public CreateConfigurationRejected(Guid id, string reason, string code)
        {
            Id = id;
            Reason = reason;
            Code = code;
        }
    }
}