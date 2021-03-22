using Ege.Net;
using AdaMedicine.ServiceModel.Dto;

namespace AdaMedicine.ServiceModel.Request
{
    [Route("/hospitals", "GET", Summary = "Get all hospitals")]
    public class GetHospitals : IReturn<ListResponse<HospitalDto>>
    {
    }
}
