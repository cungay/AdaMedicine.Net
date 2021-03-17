using Ege.Net;
using AdaMedicine.ServiceModel.Dto;

namespace AdaMedicine.ServiceModel.Request
{
    //[Tag("Hospital Requests")]
    [Route("/hospitals/{Id}", "GET", Summary = "Get hospital by id")]
    public class GetHospital : IReturn<SingleResponse<HospitalDto>>
    {
        [ApiMember(ParameterType = "path", DataType = "integer", Format = "int32", IsRequired = false, Route = "/hospitals/{Id}")]
        public int? Id { get; set; }
    }
}
