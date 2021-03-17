namespace AdaMedicine.ServiceModel.Domain
{
    public class Advert : BaseEntity
    {
        public int HospitalId { get; set; }

        public string Title { get; set; }

        public string ShortContent { get; set; }

        public string DetailContent { get; set; }

        public string ThumbImageUrl { get; set; }

        public string LargeImageUrl { get; set; }
    }
}
