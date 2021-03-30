using System.Runtime.Serialization;

namespace AdaMedicine.ServiceModel.Dto
{
    [DataContract]
    public class StaffDto
    {
        [DataMember]
        public int? Id { get; set; }

        [DataMember]
        public string StaffName { get; set; }

        [DataMember]
        public int? YearOfBirth { get; set; }

        [DataMember]
        public string Languages { get; set; }

        [DataMember]
        public string Education { get; set; }

        [DataMember]
        public string Experience { get; set; }

        [DataMember]
        public string Article { get; set; }

        [DataMember]
        public string Memberships { get; set; }

        [DataMember]
        public string Courses { get; set; }

        [DataMember]
        public string Certifications { get; set; }

        [DataMember]
        public string ImageUrl { get; set; }
    }
}
