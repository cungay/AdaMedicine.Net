using Ege.Net;
using AdaMedicine.ServiceModel.Dto;

namespace AdaMedicine.ServiceModel.Request
{
    [Route("/hospital-units", "GET", Summary = "Get all hospital units")]
    [Route("/hospital-units/{categoryid}", "GET", Summary = "Get all hospital units by category id")]
    [Route("/hospitals/{hospitalid}/units", "GET", Summary = "Get all hospital units")]
    public class GetUnits : IReturn<ListResponse<HospitalUnitDto>>
    {
        [ApiMember(ParameterType = "path", DataType = "integer", Format = "int32", IsRequired = false, 
            Route = "/hospital-units/{categoryid}")]
        public int? CategoryId { get; set; }

        [ApiMember(ParameterType = "path", DataType = "integer", Format = "int32", IsRequired = false,
            Route = "/hospitals/{hospitalid}/units")]
        public int? HospitalId { get; set; }
    }
}
