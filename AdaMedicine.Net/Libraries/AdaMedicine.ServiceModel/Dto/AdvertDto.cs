namespace AdaMedicine.ServiceModel.Dto
{
    public class AdvertDto
    {
        public virtual int? Id { get; set; }

        public virtual string Title { get; set; }

        public virtual string ShortContent { get; set; }

        public virtual string DetailContent { get; set; }

        public virtual string ThumbImageUrl { get; set; }

        public virtual string LargeImageUrl { get; set; }
    }

    public class AdvertDtoWithHospital : AdvertDto
    {
        public int? HospitalId { get; set; }
    }
}
