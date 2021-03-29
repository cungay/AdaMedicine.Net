using Ege.Net.DataAnnotations;

namespace AdaMedicine.ServiceModel.Domain
{
    [Alias("Hospital_Staff")]
    public partial class HospitalStaff
    {
        public int HospitalId { get; set; }

        public int StaffCategoryId { get; set; }

        public int StaffId { get; set; }
    }
}
