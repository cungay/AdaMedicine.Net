using Ege.Net;
using AdaMedicine.ServiceModel.Dto;

namespace AdaMedicine.ServiceModel.Request
{
    [Route("/adverts/{id}", "GET", Summary = "Get advert by id")]
    public class GetAdvert : IReturn<SingleResponse<AdvertDtoWithHospital>>
    {
        [ApiMember(ParameterType = "path", DataType = "integer", Format = "int32", IsRequired = false, Route = "/adverts/{id}")]
        public int Id { get; set; }
    }
}
