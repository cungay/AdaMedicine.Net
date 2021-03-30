using System.Runtime.Serialization;

namespace AdaMedicine.ServiceModel.Dto
{
    [DataContract]
    public class DoctorDto
    {
        [DataMember]
        public int? Id { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string FullName { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string YearOfBirth { get; set; }

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
        public string Cv { get; set; }

        [DataMember]
        public string ImageUrl { get; set; }
    }
}
