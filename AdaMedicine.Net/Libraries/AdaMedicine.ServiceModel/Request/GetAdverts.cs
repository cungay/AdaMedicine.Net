using Ege.Net;
using AdaMedicine.ServiceModel.Dto;

namespace AdaMedicine.ServiceModel.Request
{
    [Route("/hospitals/{hospitalid}/adverts", "GET", Summary = "Get all adverts by hospital id")]
    public class GetAdverts : IReturn<ListResponse<AdvertDto>>
    {
        [ApiMember(ParameterType = "path", DataType = "integer", Format = "int32", IsRequired = false, 
            Route = "/hospitals/{hospitalid}/adverts")]
        public int HospitalId { get; set; }
    }
}
