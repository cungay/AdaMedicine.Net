using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AdaMedicine.ServiceModel.Dto
{
    [DataContract]
    public class HospitalUnit
    {
        public HospitalUnit()
        {
            this.SubCategories = new List<UnitCategoryDto>();
            this.Category = new UnitCategoryDto();
        }

        public UnitCategoryDto Category { get; set; }

        public List<UnitCategoryDto> SubCategories { get; set; }
    }
}
