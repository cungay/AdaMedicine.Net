using Ege.Net;
using AdaMedicine.ServiceModel.Dto;

namespace AdaMedicine.ServiceModel.Request
{
    //[Tag("Staff Category Requests")]
    [Route("/staff-categories/{Id}", "GET", Summary = "Get staff category by id")]
    public class GetStaffCategory : IReturn<SingleResponse<StaffCategoryDto>>
    {
        [ApiMember(ParameterType = "path", DataType = "integer", Format = "int32", IsRequired = false, Route = "/staff-categories/{Id}")]
        public int Id { get; set; }
    }
}
