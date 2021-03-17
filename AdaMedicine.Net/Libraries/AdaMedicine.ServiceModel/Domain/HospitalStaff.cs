using Ege.Net.Data;
using System;
using System.Runtime.Serialization;

namespace AdaMedicine.ServiceModel.Domain
{
    public class HospitalStaff : IEntity<int>
    {
        public int Id { get; set; }

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

        [IgnoreDataMember]
        public bool Published { get; set; }

        [IgnoreDataMember]
        public bool Deleted { get; set; }

        [IgnoreDataMember]
        public DateTime CreatedOnUtc { get; set; }

        [IgnoreDataMember]
        public DateTime UpdatedOnUtc { get; set; }

    }
}
