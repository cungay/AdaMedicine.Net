using System.Runtime.Serialization;

namespace AdaMedicine.ServiceModel.Dto
{
    [DataContract]
    public class UnitCategoryDto
    {
        [DataMember]
        public int? Id { get; set; }

        [DataMember]
        public int? CategoryId { get; set; }

        [DataMember]
        public string UnitName { get; set; }

        [DataMember]
        public string ShortName { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string ImageUrl { get; set; }

        [DataMember]
        public string HtmlContent { get; set; }
    }
}
