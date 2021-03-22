using Ege.Net.DataAnnotations;

namespace AdaMedicine.ServiceModel.Domain
{
    public partial class UnitCategory : BaseEntity
    {
        [Alias("SubCategoryId")]
        public int? CategoryId { get; set; }

        public string CategoryName { get; set; }
        
        public string ShortName { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string HtmlContent { get; set; }
    }
}
