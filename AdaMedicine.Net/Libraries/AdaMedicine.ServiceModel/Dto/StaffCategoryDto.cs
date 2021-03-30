using System.Runtime.Serialization;

namespace AdaMedicine.ServiceModel.Dto
{
    [DataContract]
    public class StaffCategoryDto
    {
        [DataMember]
        public int? Id { get; set; }

        [DataMember]
        public string CategoryName { get; set; }

        [DataMember]
        public string ShortName { get; set; }

        [DataMember]
        public int? StaffCount { get; set; }
    }
}
