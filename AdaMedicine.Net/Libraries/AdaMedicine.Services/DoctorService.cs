using AdaMedicine.ServiceModel.Dto;
using AdaMedicine.ServiceModel.Request;
using Ege.Net;
using Ege.Net.Orm;
using System.Threading.Tasks;

namespace AdaMedicine.Services
{
    public class DoctorService : BaseRestService
    {
        public async Task<ListResponse<DoctorDto>> Get(GetDoctors request)
        {
            var response = new ListResponse<DoctorDto>();
            var sqlQuery = GetSqlQueryFromFile(SqlFileNames.Get_Hospital_Doctors);
            response.Result = await Task.FromResult(
                Db.SqlListAsync<DoctorDto>(sqlQuery,
                new
                {
                    hospitalId = request.HospitalId,
                    unitId = request.UnitId,
                    published = true,
                    deleted = false
                })).Result;
            return response;
        }

        public async Task<SingleResponse<DoctorDto>> Get(GetDoctor request)
        {
            var response = new SingleResponse<DoctorDto>();
            return response;
        }
    }
}
