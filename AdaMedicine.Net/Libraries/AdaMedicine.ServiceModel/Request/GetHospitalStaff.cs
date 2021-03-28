using Ege.Net;
using AdaMedicine.ServiceModel.Dto;

namespace AdaMedicine.ServiceModel.Request
{
    [Route("/hospital-staff/{id}", "GET", Summary = "Get hospital staff by id")]
    public class GetHospitalStaff: IReturn<SingleResponse<StaffDto>>
    {
        [ApiMember(ParameterType = "path", DataType = "integer", Format = "int32", IsRequired = false, 
            Route = "/hospital-staff/{id}")]
        public int? Id { get; set; }
    }
}
