using Ege.Net;
using Ege.Net.Orm;
using AdaMedicine.ServiceModel.Dto;
using AdaMedicine.ServiceModel.Request;
using System.Linq;
using System.Threading.Tasks;

namespace AdaMedicine.Services
{
    public class StaffCategoryService : BaseRestService
    {
        public async Task<ListResponse<StaffCategoryDto>> Get(GetStaffCategories request)
        {
            var response = new ListResponse<StaffCategoryDto>();
            var sqlQuery = GetSqlQueryFromFile(SqlFileNames.Get_Hospital_Staff_Categories_By_Hospital_Id);
            response.Result = await Task.FromResult(
                Db.SqlListAsync<StaffCategoryDto>(sqlQuery,
                new {
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
