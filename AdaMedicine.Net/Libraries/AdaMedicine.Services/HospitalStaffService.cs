using Ege.Net;
using Ege.Net.Orm;
using Ege.Net.Text;
using AdaMedicine.ServiceModel.Dto;
using AdaMedicine.ServiceModel.Request;
using AdaMedicine.ServiceModel.Domain;
using System.Threading.Tasks;
using System;

namespace AdaMedicine.Services
{
    public class HospitalStaffService : BaseRestService
    {
        public async Task<SingleResponse<StaffDto>> Get(GetHospitalStaff request)
        {
            if (request.Id.IsNull())
                throw new ArgumentNullException(nameof(request.Id));
            var response = new SingleResponse<StaffDto>();
            var query = Db.From<Staff>();
            query.Where(p => p.Id == request.Id);
            query.Where(p => p.Published);
            query.Where(p => !p.Deleted);
            response.Result = await Task.FromResult(Db.SingleAsync(query).Result.ConvertTo<StaffDto>())
                ?? new StaffDto();
            return response;
        }

        public async Task<ListResponse<StaffDto>> Get(GetAllHospitalStaff request)
        {
            if (request.HospitalId.IsNull())
                throw new ArgumentNullException(nameof(request.HospitalId));
            if (request.CategoryId.IsNull())
                throw new ArgumentNullException(nameof(request.CategoryId));
            var response = new ListResponse<StaffDto>();
            var sqlQuery = GetSqlQueryFromFile(SqlFileNames.Get_Staff_List);
            response.Result = await Task.FromResult(
                Db.SqlListAsync<StaffDto>(sqlQuery,
                new
                {
                    categoryId = request.CategoryId,
                    hospitalId = request.HospitalId,
                    published = true,
                    deleted = false
                })).Result;
            return response;
        }
    }
}
