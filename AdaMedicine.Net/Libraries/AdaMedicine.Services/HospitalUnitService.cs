using Ege.Net;
using Ege.Net.Orm;
using AdaMedicine.ServiceModel.Domain;
using AdaMedicine.ServiceModel.Dto;
using AdaMedicine.ServiceModel.Request;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace AdaMedicine.Services
{
    public class HospitalUnitService : RestService
    {
        public async Task<ListResponse<HospitalUnitDto>> Get(GetUnits request)
        {
            ListResponse<HospitalUnitDto> response = new() { Result = new List<HospitalUnitDto>() };
            var query = Db.From<UnitCategory>();
            if (!request.Id.IsNull())
                query.Where(p => p.Id == request.Id);
            query.Where(Sql.Custom("SubCategoryId IS NULL"));
            query.Where(p => p.Published && !p.Deleted);
            var units = await Task.FromResult(Db.SelectAsync(query).Result.ConvertAll(p => p.ConvertTo<UnitCategoryDto>()));
            if (units.Count > 0) {
                var details = await Task.FromResult(Db.SelectAsync(Db.From<UnitCategory>()
                    .OrderBy(p => p.CategoryName)
                    .Where(p => Sql.In(p.UnitId, units.ConvertAll(p => p.Id)))
                    .Where(p => p.Published && !p.Deleted)).Result.ConvertAll(p => p.ConvertTo<UnitCategoryDto>()));
                var hospitalUnitLookup = details.ToLookup(o => o.UnitId);
                var dto = units.ConvertAll(o => new HospitalUnitDto {
                    Unit = o,
                    Details = hospitalUnitLookup[o.Id].ToList()
                });
                response.Result = dto;
            }
            return response;
        }

        public async Task<ListResponse<HospitalUnitDto>> Get(GetHospitalUnits request)
        {
            throw new NotImplementedException();
        }
    }
}
