using System;

namespace AdaMedicine.Net.Core.Domain
{
    public partial class Advert : BaseEntity
    {
        public int HospitalId { get; set; }

        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public string ImageUrl { get; set; }

        public int DisplayOrder { get; set; }

        public DateTime CreatedOnUtc { get; set; }
    }
}
