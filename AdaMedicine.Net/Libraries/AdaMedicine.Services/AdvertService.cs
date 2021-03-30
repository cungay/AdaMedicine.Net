using Ege.Net;
using Ege.Net.Orm;
using AdaMedicine.ServiceModel.Domain;
using AdaMedicine.ServiceModel.Dto;
using AdaMedicine.ServiceModel.Request;
using System.Threading.Tasks;
using System;

namespace AdaMedicine.Services
{
    public class AdvertService : RestService
    {
        public async Task<SingleResponse<AdvertDtoWithHospital>> Get(GetAdvert request)
        {
            if (request.Id.IsNull())
                throw new ArgumentNullException(nameof(request.Id));
            var response = new SingleResponse<AdvertDtoWithHospital>();
            var query = Db.From<Advert>();
            query.Where(p => p.Id == request.Id);
            query.Where(p => p.Published);
            query.Where(p => !p.Deleted);
            response.Result = await Task.FromResult(
                Db.SingleAsync(query).Result.ConvertTo<AdvertDtoWithHospital>())
                ?? new AdvertDtoWithHospital();
            return response;
        }

        public async Task<ListResponse<AdvertDto>> Get(GetAdverts request)
        {
            if (request.HospitalId.IsNull())
                throw new ArgumentNullException(nameof(request.HospitalId));
            var response = new ListResponse<AdvertDto>();
            var query = Db.From<Advert>();
            query.Where(p => p.HospitalId == request.HospitalId);
            query.Where(p => p.Published);
            query.Where(p => !p.Deleted);
            query.OrderBy(p => p.Id);
            response.Result = await Task.FromResult(Db.SelectAsync(query).Result.ConvertAll(p => p.ConvertTo<AdvertDto>()));
            return response;
        }
    }
}
