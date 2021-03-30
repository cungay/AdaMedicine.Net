using Ege.Net;
using Ege.Net.Orm;
using AdaMedicine.ServiceModel.Dto;
using AdaMedicine.ServiceModel.Request;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace AdaMedicine.Services
{
    public class DoctorService : BaseRestService
    {
        public async Task<ListResponse<DoctorDto>> Get(GetDoctors request)
        {
            /*
            if (request.HospitalId.IsNull())
                throw new ArgumentNullException(nameof(request.HospitalId));
            if (request.UnitId.IsNull())
                throw new ArgumentNullException(nameof(request.UnitId));
            */
            var response = new ListResponse<DoctorDto>
            {
                Result = await Task.FromResult(
                GetHospitalDoctors(hospitalId: request.HospitalId, unitId: request.UnitId).Result)
            };
            return response;
        }

        public async Task<SingleResponse<DoctorDto>> Get(GetDoctor request)
        {
            if (request.Id.IsNull())
                throw new ArgumentNullException(nameof(request.Id));
            var response = new SingleResponse<DoctorDto>
            {
                Result = await Task.FromResult(
                GetHospitalDoctors(doctorId: request.Id).Result.FirstNonDefault())
                ?? new DoctorDto()
            };
            return response;
        }

        private async Task<List<DoctorDto>> GetHospitalDoctors(int? doctorId = null, int? hospitalId = null, int? unitId = null,
            bool isPublished = true, bool isDeleted = false)
        {
            var sqlQuery = GetSqlQueryFromFile(SqlFileNames.Get_Hospital_Doctors);
            var pDid = Db.CreateParam("doctorId", doctorId, dbType: DbType.Int32);
            var pHid = Db.CreateParam("hospitalId", hospitalId, dbType: DbType.Int32);
            var pUid = Db.CreateParam("unitId", unitId, dbType: DbType.Int32);
            var pIsPublished = Db.CreateParam("published", isPublished, dbType: DbType.Boolean);
            var pIsdeleted = Db.CreateParam("deleted", isDeleted, dbType: DbType.Boolean);
            var doctors = await Db.SqlListAsync<DoctorDto>(sqlQuery, new[] { pDid, pHid, pUid, pIsPublished, pIsdeleted });
            return doctors;
        }
    }
}
