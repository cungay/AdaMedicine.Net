using Ege.Net.DataAnnotations;
using System.Runtime.Serialization;

namespace AdaMedicine.ServiceModel.Domain
{
    public class HospitalStaff : BaseEntity
    {
        [IgnoreDataMember]
        public int HospitalId { get; set; }

        public int StaffCategoryId { get; set; }

        public string Name { get; set; }

        public int YearOfBirth { get; set; }

        public string Languages { get; set; }

        public string Education { get; set; }

        public string Experience { get; set; }

        public string Article { get; set; }

        public string Memberships { get; set; }

        public string Courses { get; set; }

        public string Certifications { get; set; }

        public string ImageUrl { get; set; }

        [Ignore]
        public override int DisplayOrder { get; set; }
    }
}
