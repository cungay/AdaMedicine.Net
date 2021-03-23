using Ege.Net;
using AdaMedicine.ServiceModel.Dto;

namespace AdaMedicine.ServiceModel.Request
{
    [Route("/hospital-units", "GET", Summary = "Get all hospital units")]
    [Route("/hospital-units/{id}", "GET", Summary = "Get all hospital units by id")]
    public class GetUnits : IReturn<ListResponse<HospitalUnitDto>>
    {
        [ApiMember(ParameterType = "path", DataType = "integer", Format = "int32", IsRequired = false, Route = "/hospital-units/{id}")]
        public int? Id { get; set; }
    }
}
