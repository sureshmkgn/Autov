using System;

namespace Autovoice.Common.Types
{
    public interface IIdentifiable
    {
         Guid Id { get; }

        string Name { get; }
    }
}