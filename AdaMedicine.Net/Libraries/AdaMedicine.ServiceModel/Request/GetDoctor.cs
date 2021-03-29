using Ege.Net;
using AdaMedicine.ServiceModel.Dto;

namespace AdaMedicine.ServiceModel.Request
{
    [Route("/doctors/{id}", "GET", Summary = "Get hospital doctor by id")]
    public class GetDoctor : IReturn<SingleResponse<DoctorDto>>
    {
        public int? Id { get; set; }
    }
}
