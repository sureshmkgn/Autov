using Autovoice.Common.Messages;
using Newtonsoft.Json;
using System;

namespace Autovoice.Services.Configurations.Messages.Commands
{
	public class CreateConfiguration : ICommand
	{
		public Guid Id { get; }
		public string Name { get; }

        public string Value { get; }


        [JsonConstructor]
		public CreateConfiguration(Guid id, string name,string value)
		{
			Id = id;
			Name = name;
            Value = Value;

        }
	}
}