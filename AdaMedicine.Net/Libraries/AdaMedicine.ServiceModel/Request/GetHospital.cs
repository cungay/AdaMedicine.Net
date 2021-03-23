using Ege.Net;
using AdaMedicine.ServiceModel.Dto;

namespace AdaMedicine.ServiceModel.Request
{
    [Route("/hospitals/{hospitalid}", "GET", Summary = "Get hospital by id")]
    public class GetHospital : IReturn<SingleResponse<HospitalDto>>
    {
        [ApiMember(ParameterType = "path", DataType = "integer", Format = "int32", IsRequired = false, Route = "/hospitals/{hospitalid}")]
        public int? HospitalId { get; set; }
    }
}
