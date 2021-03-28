using Ege.Net;
using AdaMedicine.ServiceModel.Dto;

namespace AdaMedicine.ServiceModel.Request
{
    [Route("/hospitals/{hospitalid}/staff-categories/{categoryid}/staff-list", "GET", 
        Summary = "Get all hospital staff by category id")]
    public class GetAllHospitalStaff : IReturn<ListResponse<StaffDto>>
    {
        public int? HospitalId { get; set; }

        public int? CategoryId { get; set; }

        //[QueryDbField(Template = "dbo.Fn_CleanValue({Field}) LIKE '%' + dbo.Fn_CleanValue({Value}) + '%'", Field = "Name")]
        //public string Name { get; set; }

        //public int? YearOfBirth { get; set; }

        //public string Languages { get; set; }

        //public string Education { get; set; }

        //public string Experience { get; set; }
    }
}
