using Ege.Net;
using Ege.Net.Orm;
using AdaMedicine.ServiceModel.Domain;
using AdaMedicine.ServiceModel.Dto;
using AdaMedicine.ServiceModel.Request;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AdaMedicine.Services
{
    public class HospitalUnitService : BaseRestService
    {
        public async Task<ListResponse<HospitalUnitDto>> Get(GetUnits request) {
            ListResponse<HospitalUnitDto> response = new() { Result = new List<HospitalUnitDto>() };
            var sqlQuery = GetSqlQueryFromFile(SqlFileNames.Get_Hospital_Units);
            var units = await Task.FromResult(
                Db.SqlListAsync<UnitCategory>(sqlQuery,
                new {
                    categoryId = request.CategoryId,
                    hospitalId = request.HospitalId,
                    published = true,
                    deleted = false
                }).Result.ConvertAll(p => p.ConvertTo<UnitCategoryDto>()));
            if (units.Count > 0) {
                var details = await Task.FromResult(Db.SelectAsync(Db.From<UnitCategory>()
                    .OrderBy(p => p.Name)
                    .Where(p => Sql.In(p.CategoryId, units.ConvertAll(p => p.Id)))
                    .Where(p => p.Published && !p.Deleted)).Result.ConvertAll(p => p.ConvertTo<UnitCategoryDto>()));
                var unitsLookUp = details.ToLookup(o => o.CategoryId);
                var dto = units.ConvertAll(o => new HospitalUnitDto {
                    Category = o,
                    Units = unitsLookUp[o.Id].ToList()
                });
                response.Result = dto;
            }
            return response;
        }
    }
}
