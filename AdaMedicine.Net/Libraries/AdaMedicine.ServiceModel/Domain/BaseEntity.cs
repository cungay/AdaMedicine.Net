using Ege.Net.Data;
using System.Runtime.Serialization;
using System;

namespace AdaMedicine.ServiceModel.Domain
{
    public abstract class BaseEntity : IEntity<int>
    {
        [DataMember(Order = 1)]
        public virtual int Id { get; set; }

        [IgnoreDataMember]
        public virtual int DisplayOrder { get; set; }

        [IgnoreDataMember]
        public virtual bool Published { get; set; }

        [IgnoreDataMember]
        public virtual bool Deleted { get; set; }

        [IgnoreDataMember]
        public virtual DateTime CreatedOnUtc { get; set; }

        [IgnoreDataMember]
        public virtual DateTime UpdatedOnUtc { get; set; }
    }
}
