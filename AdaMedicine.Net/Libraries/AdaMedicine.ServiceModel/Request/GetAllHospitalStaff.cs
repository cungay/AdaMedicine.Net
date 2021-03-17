using Ege.Net;
using AdaMedicine.ServiceModel.Domain;

namespace AdaMedicine.ServiceModel.Request
{
    [Route("/hospital-staff", "GET", Summary = "Get all hospital staff")]
    public class GetAllHospitalStaff : QueryDb<HospitalStaff>
    {
        public int? HospitalId { get; set; }

        public int? StaffCategoryId { get; set; }

        [QueryDbField(Template = "dbo.Fn_CleanValue({Field}) LIKE '%' + dbo.Fn_CleanValue({Value}) + '%'", Field = "Name")]
        public string Name { get; set; }
    }
}
