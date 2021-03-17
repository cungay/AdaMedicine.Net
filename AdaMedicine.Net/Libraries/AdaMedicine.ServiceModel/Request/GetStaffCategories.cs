using Ege.Net;
using AdaMedicine.ServiceModel.Dto;

namespace AdaMedicine.ServiceModel.Request
{
    //[Tag("Staff Category Requests")]
    [Route("/staff-categories", "GET", Summary = "Get all staff categories")]
    [Route("/hospitals/{hospitalid}/staff-categories", "GET", Summary = "Get all staff categories by hospital id")]
    public class GetStaffCategories : IReturn<ListResponse<StaffCategoryDto>>
    {
        [ApiMember(ParameterType = "path", DataType = "integer", Format = "int32", IsRequired = false, Route = "/hospitals/{hospitalid}/staff-categories")]
        public int? HospitalId { get; set; }

        [ApiMember(ParameterType = "path", DataType = "integer", Format = "int32", IsRequired = false, Route = "/staff-categories/{id}")]
        public int? Id { get; set; }
    }
}
