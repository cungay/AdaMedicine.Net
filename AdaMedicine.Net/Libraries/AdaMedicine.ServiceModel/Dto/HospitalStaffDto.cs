namespace AdaMedicine.ServiceModel.Dto
{
    public class HospitalStaffDto
    {
        public int? Id { get; set; }

        public int? HospitalId { get; set; }

        public int? StaffCategoryId { get; set; }

        public string Name { get; set; }

        public int? YearOfBirth { get; set; }

        public string Languages { get; set; }

        public string Education { get; set; }

        public string Experience { get; set; }

        public string Article { get; set; }

        public string Memberships { get; set; }

        public string Courses { get; set; }

        public string Certifications { get; set; }

        public string ImageUrl { get; set; }
    }
}
