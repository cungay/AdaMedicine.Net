using Ege.Net.Data;
using System.Runtime.Serialization;
using System;

namespace AdaMedicine.ServiceModel.Domain
{
    public abstract class BaseEntity : IEntity<int>
    {
        public virtual int Id { get; set; }

        public virtual bool Published { get; set; }

        public virtual bool Deleted { get; set; }

        public virtual DateTime CreatedOnUtc { get; set; }

        public virtual DateTime UpdatedOnUtc { get; set; }
    }
}
