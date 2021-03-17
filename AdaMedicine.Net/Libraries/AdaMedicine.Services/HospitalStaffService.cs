using Ege.Net;
using Ege.Net.Orm;
using AdaMedicine.ServiceModel.Dto;
using AdaMedicine.ServiceModel.Request;
using AdaMedicine.ServiceModel.Domain;
using System.Threading.Tasks;
using Ege.Net.Text;

namespace AdaMedicine.Services
{
    public class HospitalStaffService : RestService
    {
        public async Task<SingleResponse<HospitalStaffDto>> Get(GetHospitalStaff request)
        {
            var response = new SingleResponse<HospitalStaffDto>();
            var query = Db.From<HospitalStaff>();
            if (!request.Id.IsNull())
                query.Where(p => p.Id == request.Id);
            response.Result = await Task.FromResult(Db.SingleAsync(query).Result.ConvertTo<HospitalStaffDto>()) ?? new HospitalStaffDto();
            /*
            if (response.Result is null)
            {
                response.Result = new HospitalStaffDto();
                return new HttpResult(response);
            }
            return new HttpResult(response)
            {
                ResultScope = () => JsConfig.With(new Config
                {
                    IncludeNullValues = true,
                })
            };
            */
            return response;
        }
    }
}
