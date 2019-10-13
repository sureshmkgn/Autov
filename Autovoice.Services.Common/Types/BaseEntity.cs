using System;

namespace Autovoice.Common.Types
{
    public abstract class BaseEntity : IIdentifiable
    {
        public Guid Id { get; protected set; }
        public DateTime CreatedDate { get; protected set; } 
        public DateTime UpdatedDate { get; protected set; }

        public string Name { get; protected set; }

        public BaseEntity(Guid id,string name)
        {
            Id = id;
            Name = name;
            CreatedDate = DateTime.UtcNow;
            SetUpdatedDate();
        }

        protected virtual void SetUpdatedDate()
            => UpdatedDate = DateTime.UtcNow;
    }
}