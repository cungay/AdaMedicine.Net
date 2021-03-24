using Ege.Net;
using Ege.Net.Orm;
using AdaMedicine.ServiceModel.Dto;
using AdaMedicine.ServiceModel.Request;
using AdaMedicine.ServiceModel.Domain;
using System.Threading.Tasks;
using Ege.Net.Text;

namespace AdaMedicine.Services
{
    public class HospitalStaffService : RestService
    {
        public async Task<SingleResponse<HospitalStaffDto>> Get(GetHospitalStaff request)
        {
            var response = new SingleResponse<HospitalStaffDto>();
            var query = Db.From<HospitalStaff>();
            if (!request.Id.IsNull())
                query.Where(p => p.Id == request.Id);
            query.Where(p => p.Published);
            query.Where(p => !p.Deleted);
            response.Result = await Task.FromResult(Db.SingleAsync(query).Result.ConvertTo<HospitalStaffDto>()) 
                ?? new HospitalStaffDto();
            return response;
        }

        public async Task<ListResponse<HospitalStaffDto>> Get(GetAllHospitalStaff request)
        {
            var response = new ListResponse<HospitalStaffDto>();
            var query = Db.From<HospitalStaff>();
            if (request.HospitalId.IsNull() && request.CategoryId.IsNull())
                return response;
            if (!request.HospitalId.IsNull())
                query.Where(p => p.Id == request.HospitalId);
            if (!request.CategoryId.IsNull())
                query.Where(p => p.StaffCategoryId == request.CategoryId);
            query.Where(p => p.Published);
            query.Where(p => !p.Deleted);
            query.OrderBy(p => p.Id);
            //if (!request.Name.IsNullOrEmpty())
            //    query.Where(Sql.Custom($"dbo.Fn_CleanValue(Name) LIKE '%' + dbo.Fn_CleanValue('{request.Name') + xz'%'"));
            //if (!request.YearOfBirth.IsNull())
            //    query.Where(p => p.YearOfBirth == request.YearOfBirth);
            //if (!request.Languages.IsNullOrEmpty())
            //    query.Where(Sql.Custom($"dbo.Fn_CleanValue(Languages) LIKE '%' + dbo.Fn_CleanValue('{request.Languages}') + '%'"));
            //if (!request.Education.IsNullOrEmpty())
            //    query.Where(Sql.Custom($"dbo.Fn_CleanValue(Education) LIKE '%' + dbo.Fn_CleanValue('{request.Education}') + '%'"));
            //if (!request.Experience.IsNullOrEmpty())
            //    query.Where(Sql.Custom($"dbo.Fn_CleanValue(Experience) LIKE '%' + dbo.Fn_CleanValue('{request.Experience}') + '%'"));
            response.Result = await Task.FromResult(Db.SelectAsync(query).Result.ConvertAll(p => p.ConvertTo<HospitalStaffDto>()));
            return response;
        }
    }
}
