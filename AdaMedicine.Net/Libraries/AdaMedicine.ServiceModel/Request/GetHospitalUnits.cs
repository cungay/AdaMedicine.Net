using Ege.Net;
using AdaMedicine.ServiceModel.Dto;

namespace AdaMedicine.ServiceModel.Request
{
    [Route("/hospitals/{hospitalid}/units", "GET", Summary = "Get all hospital units")]
    public class GetHospitalUnits : IReturn<ListResponse<HospitalUnitDto>>
    {
        [ApiMember(ParameterType = "path", DataType = "integer", Format = "int32", IsRequired = false, Route = "/hospitals/{hospitalid}/units")]
        public int? HospitalId { get; set; }
    }
}
