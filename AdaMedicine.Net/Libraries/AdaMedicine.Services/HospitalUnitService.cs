using Ege.Net;
using Ege.Net.Orm;
using AdaMedicine.ServiceModel.Domain;
using AdaMedicine.ServiceModel.Dto;
using AdaMedicine.ServiceModel.Request;
using System.Linq;
using System.Threading.Tasks;

namespace AdaMedicine.Services
{
    public class HospitalUnitService : RestService
    {
        public async Task<SingleResponse<HospitalUnitDto>> Get(GetHospitalUnit request)
        {
            var response = new SingleResponse<HospitalUnitDto>();
            var unitCategory = await Task.FromResult(Db.SingleAsync<UnitCategory>
                (p => p.Id == request.Id && p.Published && !p.Deleted)).Result;
            if (unitCategory == null)
                return new SingleResponse<HospitalUnitDto>();
            var subCategories = Db.SelectAsync(Db.From<UnitCategory>().OrderBy(p => p.CategoryName)
                .Where(p => Sql.In(p.CategoryId, unitCategory.Id)));
            var hospitalUnitLookup = await Task.FromResult(subCategories.Result.ToLookup(o => o.CategoryId));
            HospitalUnitDto dto = new()
            {
                Category = unitCategory.ConvertTo<UnitCategoryDto>(),
                SubCategories = hospitalUnitLookup[unitCategory.Id].ToList().ConvertAll(p => p.ConvertTo<UnitCategoryDto>())
            };
            response.Result = dto;
            return response;
        }
    }
}
