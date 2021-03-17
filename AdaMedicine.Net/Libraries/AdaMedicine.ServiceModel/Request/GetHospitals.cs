using Ege.Net;
using AdaMedicine.ServiceModel.Domain;

namespace AdaMedicine.ServiceModel.Request
{
    //[Tag("Hospital Requests")]
    [Route("/hospitals", "GET", Summary = "Get all hospitals")]
    public class GetHospitals : QueryDb<Hospital>
    {
        [QueryDbField(Template = "dbo.Fn_CleanValue({Field}) LIKE '%' + dbo.Fn_CleanValue({Value}) + '%'", Field = "Title")]
        public string Title { get; set; }

        [QueryDbField(Template = "dbo.Fn_CleanValue({Field}) = dbo.Fn_CleanValue({Value})", Field = "Code")]
        public string Code { get; set; }

        [QueryDbField(Template = "dbo.Fn_CleanValue({Field}) LIKE '%' + dbo.Fn_CleanValue({Value}) + '%'", Field = "ShortName")]
        public string ShortName { get; set; }
    }
}
