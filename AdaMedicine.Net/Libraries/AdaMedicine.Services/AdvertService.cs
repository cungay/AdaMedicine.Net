﻿using Ege.Net;
using Ege.Net.Orm;
using AdaMedicine.ServiceModel.Domain;
using AdaMedicine.ServiceModel.Dto;
using AdaMedicine.ServiceModel.Request;
using System.Threading.Tasks;

namespace AdaMedicine.Services
{
    public class AdvertService : RestService
    {
        public async Task<SingleResponse<AdvertDtoWithHospital>> Get(GetAdvert request)
        {
            var response = new SingleResponse<AdvertDtoWithHospital>();
            var query = Db.From<Advert>();
            if (!request.Id.IsNull())
                query.Where(p => p.Id == request.Id);
            response.Result = await Task.FromResult(Db.SingleAsync(query).Result.ConvertTo<AdvertDtoWithHospital>()) 
                ?? new AdvertDtoWithHospital();
            return response;
        }

        public async Task<ListResponse<AdvertDto>> Get(GetAdverts request)
        {
            var response = new ListResponse<AdvertDto>();
            var query = Db.From<Advert>();
            if (!request.HospitalId.IsNull())
                query.Where(p => p.HospitalId == request.HospitalId);
            response.Result = await Task.FromResult(Db.SelectAsync(query).Result.ConvertAll(p => p.ConvertTo<AdvertDto>()));
            //response.Result.Each(p => p.HospitalId = null);
            return response;
        }
    }
}
