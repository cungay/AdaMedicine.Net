using Ege.Net;
using AdaMedicine.ServiceModel.Dto;

namespace AdaMedicine.ServiceModel.Request
{
    [Route("/hospital-unit/{id}", "GET", Summary = "Get all hospital units by id")]
    public class GetHospitalUnit : IReturn<ListResponse<HospitalUnitDto>>
    {
        [ApiMember(ParameterType = "path", DataType = "integer", Format = "int32", IsRequired = false, Route = "/hospital-unit/{id}")]
        public int? Id { get; set; }
    }
}
