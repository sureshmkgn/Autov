using Autovoice.Common.Types;
using Autovoice.Services.Configurations.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autovoice.Services.Products.Queries
{
    public class GetConfigurationByKey : IQuery<ConfigurationDto>
    {
        public string Key { get; set; }

        

    }
}
