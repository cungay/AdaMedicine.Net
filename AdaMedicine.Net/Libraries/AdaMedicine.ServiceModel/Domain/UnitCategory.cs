namespace AdaMedicine.ServiceModel.Domain
{
    public partial class UnitCategory : BaseEntity
    {
        public string CategoryName { get; set; }

        public string ShortDescription { get; set; }

        public string ImageUrl { get; set; }
    }
}
