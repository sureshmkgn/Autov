using Autovoice.Common.Types;
using Autovoice.Services.Configurations.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autovoice.Services.Configurations.Queries
{
    public class GetConfiguration : IQuery<ConfigurationDto>
    {
        public Guid Id { get; set; }

        public string Key { get; set; }
        public string Value { get; set; }


    }
}
