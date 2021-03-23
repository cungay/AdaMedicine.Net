using System.Runtime.Serialization;

namespace AdaMedicine.ServiceModel.Dto
{
    [DataContract]
    public class HospitalDto
    {
        [DataMember]
        public int? Id { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public string ShortName { get; set; }

        [DataMember]
        public string LogoUrl { get; set; }

        [DataMember]
        public string ImageUrl { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string HtmlContent { get; set; }

        [DataMember]
        public string Phone { get; set; }

        [DataMember]
        public string Fax { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Address { get; set; }
    }
}
