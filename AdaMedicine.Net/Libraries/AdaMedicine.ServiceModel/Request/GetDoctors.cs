using Ege.Net;
using AdaMedicine.ServiceModel.Dto;

namespace AdaMedicine.ServiceModel.Request
{
    [Route("/hospitals/{hospitalid}/units/{unitid}/doctors", "GET", Summary = "Get all hospital doctors")]
    public class GetDoctors : IReturn<ListResponse<DoctorDto>>
    {
        public int HospitalId { get; set; }

        public int UnitId { get; set; }
    }
}
