using Ege.Net;
using Ege.Net.Orm;
using AdaMedicine.ServiceModel.Dto;
using AdaMedicine.ServiceModel.Request;
using System.Linq;
using System.Threading.Tasks;

namespace AdaMedicine.Services
{
    public class StaffCategoryService : RestService
    {
        public async Task<ListResponse<StaffCategoryDto>> Get(GetStaffCategories request)
        {
            var response = new ListResponse<StaffCategoryDto>();
            var sqlQuery = @"SELECT DISTINCT sc.Id, sc.CategoryName, sc.ShortName, map.DisplayOrder, StaffCount = (SELECT COUNT(*) FROM dbo.HospitalStaff hs WHERE hs.HospitalId = ISNULL(@hospitalId, hs.HospitalId) AND hs.StaffCategoryId = map.StaffCategoryId) FROM [dbo].[StaffCategory] sc (NOLOCK) INNER JOIN dbo.Hospital_StaffCategory map(NOLOCK) ON sc.Id = map.StaffCategoryId WHERE sc.Published = @published AND sc.Deleted = @deleted AND map.HospitalId = ISNULL(@hospitalId, map.HospitalId) AND sc.Id = map.StaffCategoryId AND map.StaffCategoryId = ISNULL(@categoryId, map.StaffCategoryId) ORDER BY map.DisplayOrder, sc.Id";
            response.Result = await Task.FromResult(
                Db.SqlListAsync<StaffCategoryDto>(sqlQuery,
                new
                {
                    categoryId = request.Id,
                    hospitalId = request.HospitalId,
                    published = true,
                    deleted = false
                })).Result;
            return response;
        }

        public async Task<SingleResponse<StaffCategoryDto>> Get(GetStaffCategory request)
        {
            ListResponse<StaffCategoryDto> categoriesResponse = await Gateway.SendAsync(new GetStaffCategories { Id = request.Id });
            StaffCategoryDto categoryDto = categoriesResponse.Result.SingleOrDefault() ?? new StaffCategoryDto();
            return new SingleResponse<StaffCategoryDto>()
            {
                ResponseStatus = categoriesResponse.ResponseStatus,
                Result = categoryDto
            };
        }
    }
}
