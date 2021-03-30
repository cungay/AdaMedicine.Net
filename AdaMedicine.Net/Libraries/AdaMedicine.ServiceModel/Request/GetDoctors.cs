using Ege.Net;
using AdaMedicine.ServiceModel.Dto;

namespace AdaMedicine.ServiceModel.Request
{
    [Route("/hospitals/{hospitalid}/units/{unitid}/doctors", "GET", Summary = "Get all hospital doctors by unit id")]
    [Route("/hospitals/{hospitalid}/doctors", "GET", Summary = "Get all hospital doctors")]
    public class GetDoctors : IReturn<ListResponse<DoctorDto>>
    {
        [ApiMember(ParameterType = "path", DataType = "integer", Format = "int32", IsRequired = false,
            Route = "/hospitals/{hospitalid}/units/{unitid}/doctors")]
        [ApiMember(ParameterType = "path", DataType = "integer", Format = "int32", IsRequired = false, 
            Route = "/hospitals/{hospitalid}/doctors")]
        public int? HospitalId { get; set; }

        [ApiMember(ParameterType = "path", DataType = "integer", Format = "int32", IsRequired = false,
            Route = "/hospitals/{hospitalid}/units/{unitid}/doctors")]
        public int? UnitId { get; set; }
    }
}
