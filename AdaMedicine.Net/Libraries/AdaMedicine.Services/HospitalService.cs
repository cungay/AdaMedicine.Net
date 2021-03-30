using Ege.Net;
using Ege.Net.Orm;
using Ege.Net.Text;
using AdaMedicine.ServiceModel.Domain;
using AdaMedicine.ServiceModel.Dto;
using AdaMedicine.ServiceModel.Request;
using System.Threading.Tasks;
using System;

namespace AdaMedicine.Services
{
    public class HospitalService : RestService
    {
        public async Task<SingleResponse<HospitalDto>> Get(GetHospital request)
        {
            if (request.HospitalId.IsNull())
                throw new ArgumentNullException(nameof(request.HospitalId));
            var response = new SingleResponse<HospitalDto>();
            var query = Db.From<Hospital>();
            query.Where(p => p.Id == request.HospitalId);
            query.Where(p => p.Published);
            query.Where(p => !p.Deleted);
            response.Result = await Task.FromResult(
                Db.SingleAsync(query).Result.ConvertTo<HospitalDto>()) 
                ?? new HospitalDto();
            return response;
        }

        public async Task<ListResponse<HospitalDto>> Get(GetHospitals request)
        {
            var response = new ListResponse<HospitalDto>();
            var query = Db.From<Hospital>();
            query.Where(p => p.Published && !p.Deleted);
            query.Where(p => p.Published);
            query.Where(p => !p.Deleted);
            query.OrderBy(p => p.Id);
            response.Result = await Task.FromResult(Db.SelectAsync(query).Result.ConvertAll(p => p.ConvertTo<HospitalDto>()));
            return response;
        }
    }
}
