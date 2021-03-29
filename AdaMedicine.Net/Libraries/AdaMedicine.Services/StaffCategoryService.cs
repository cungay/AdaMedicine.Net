using Ege.Net;
using Ege.Net.Orm;
using AdaMedicine.ServiceModel.Dto;
using AdaMedicine.ServiceModel.Request;
using AdaMedicine.ServiceModel.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace AdaMedicine.Services
{
    public class StaffCategoryService : BaseRestService
    {
        public async Task<ListResponse<StaffCategoryDto>> Get(GetStaffCategories request)
        {
            var response = new ListResponse<StaffCategoryDto>();
            var sqlQuery = GetSqlQueryFromFile(SqlFileNames.Get_Staff_Categories);
            var categories = await Task.FromResult(
                Db.SqlListAsync<StaffCategoryDto>(sqlQuery, new {
                    hospitalId = request.HospitalId,
                    categoryId = request.Id,
                    published = true,
                    deleted = false
                })).Result;
            categories.ForEach(delegate (StaffCategoryDto dto) {
                var query = Db.From<HospitalStaff>().Join<StaffCategory>((hs, sc) => sc.Id == hs.StaffCategoryId);
                query.Where<StaffCategory>(sc => sc.Published);
                query.Where<StaffCategory>(sc => !sc.Deleted);
                if (!request.HospitalId.IsNull())
                    query.Where(hs => hs.HospitalId == request.HospitalId);
                query.Where(hs => hs.StaffCategoryId == dto.Id);
                var staffCount = Db.ScalarAsync<int>(query.Select(Sql.Count("Hospital_Staff.StaffId")));
                dto.StaffCount = staffCount.Result;
            });
            response.Result = categories;
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
