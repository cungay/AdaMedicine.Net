namespace AdaMedicine.ServiceModel.Dto
{
    public class AdvertDto
    {
        public int? Id { get; set; }

        public int? HospitalId { get; set; }

        public string Title { get; set; }

        public string ShortContent { get; set; }

        public string DetailContent { get; set; }

        public string ThumbImageUrl { get; set; }

        public string LargeImageUrl { get; set; }
    }
}
