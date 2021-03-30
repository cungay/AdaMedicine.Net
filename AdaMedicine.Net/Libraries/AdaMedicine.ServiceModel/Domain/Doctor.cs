namespace AdaMedicine.ServiceModel.Domain
{
    public partial class Doctor : BaseEntity
    {
        public int TitleId { get; set; }

        public string Title { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string YearOfBirth { get; set; }

        public string Languages { get; set; }

        public string Education { get; set; }

        public string Experience { get; set; }

        public string Article { get; set; }

        public string Memberships { get; set; }

        public string Courses { get; set; }

        public string Certifications { get; set; }

        public string Cv { get; set; }

        public string ImageUrl { get; set; }

        public string DisplayOrder { get; set; }
    }
}
