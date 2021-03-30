using System.Runtime.Serialization;

namespace AdaMedicine.ServiceModel.Dto
{
    [DataContract]
    public class AdvertDto
    {
        [DataMember]
        public virtual int? Id { get; set; }

        [DataMember]
        public virtual string Title { get; set; }

        [DataMember]
        public virtual string ShortContent { get; set; }

        [DataMember]
        public virtual string DetailContent { get; set; }

        [DataMember]
        public virtual string ThumbImageUrl { get; set; }

        [DataMember]
        public virtual string LargeImageUrl { get; set; }
    }

    [DataContract]
    public class AdvertDtoWithHospital : AdvertDto
    {
        [DataMember]
        public int? HospitalId { get; set; }
    }
}
