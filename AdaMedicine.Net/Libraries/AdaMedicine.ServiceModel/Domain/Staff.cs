namespace AdaMedicine.ServiceModel.Domain
{
    public partial class Staff : BaseEntity
    {
        public string StaffName { get; set; }

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
