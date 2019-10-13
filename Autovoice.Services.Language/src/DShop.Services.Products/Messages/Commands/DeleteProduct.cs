using Autovoice.Common.Messages;
using Newtonsoft.Json;
using System;

namespace Autovoice.Services.Products.Messages.Commands
{
	public class DeleteProduct : ICommand
	{
        public Guid Id { get; }

        [JsonConstructor]
        public DeleteProduct(Guid id)
        {
            Id = id;
        }
	}
}