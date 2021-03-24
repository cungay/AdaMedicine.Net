namespace AdaMedicine.ServiceModel.Dto
{
    public class UnitCategoryDto
    {
        public int? Id { get; set; }

        public int? UnitId { get; set; }

        public string UnitName { get; set; }

        public string ShortName { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string HtmlContent { get; set; }
    }
}
