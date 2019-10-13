using Autovoice.Common.Messages;
using Newtonsoft.Json;
using System;

namespace Autovoice.Services.Products.Messages.Commands
{
	public class CreateProduct : ICommand
	{
		public Guid Id { get; }
		public string Name { get; }
		

		[JsonConstructor]
		public CreateProduct(Guid id, string name)
		{
			Id = id;
			Name = name;
			
		}
	}
}