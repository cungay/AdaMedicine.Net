using System.Runtime.Serialization;

namespace AdaMedicine.ServiceModel.Domain
{
    public class Hospital : BaseEntity
    {
        public string Title { get; set; }

        public string Code { get; set; }

        public string ShortName { get; set; }

        public string LogoUrl { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public string HtmlContent { get; set; }

        public string Phone { get; set; }

        public string Fax { get; set; }

        public string Email { get; set; }

        [IgnoreDataMember]
        public int? CityId { get; set; }

        [IgnoreDataMember]
        public int? CountryId { get; set; }

        [IgnoreDataMember]
        public int? DistrictId { get; set; }

        [IgnoreDataMember]
        public int? NeighborhoodId { get; set; }

        public string Address { get; set; }
    }
}
