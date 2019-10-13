using Autovoice.Common.Types;
using Autovoice.Services.Products.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autovoice.Services.Products.Queries
{
    public class GetProductByName : IQuery<ProductDto>
    {
        public string Name { get; set; }

        

    }
}
