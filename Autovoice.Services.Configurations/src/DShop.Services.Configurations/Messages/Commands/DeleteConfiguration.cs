using Autovoice.Common.Messages;
using Newtonsoft.Json;
using System;

namespace Autovoice.Services.Configurations.Messages.Commands
{
	public class DeleteConfiguration : ICommand
	{
        public Guid Id { get; }

        [JsonConstructor]
        public DeleteConfiguration(Guid id)
        {
            Id = id;
        }
	}
}