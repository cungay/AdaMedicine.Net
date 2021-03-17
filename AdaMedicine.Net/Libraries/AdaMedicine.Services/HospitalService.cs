using Ege.Net;
using Ege.Net.Orm;
using Ege.Net.Text;
using AdaMedicine.ServiceModel.Domain;
using AdaMedicine.ServiceModel.Dto;
using AdaMedicine.ServiceModel.Request;
using System.Threading.Tasks;

namespace AdaMedicine.Services
{
    public class HospitalService : RestService
    {
        public async Task<SingleResponse<HospitalDto>> Get(GetHospital request)
        {
            var response = new SingleResponse<HospitalDto>();
            var query = Db.From<Hospital>();
            if (!request.Id.IsNull())
                query.Where(p => p.Id == request.Id);
            response.Result = await Task.FromResult(Db.SingleAsync(query).Result.ConvertTo<HospitalDto>()) ?? new HospitalDto();
            return response;
        }
    }
}
