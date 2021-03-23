using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AdaMedicine.ServiceModel.Dto
{
    public class HospitalUnitDto
    {
        public HospitalUnitDto()
        {
            this.Unit = new UnitCategoryDto();
            this.Details = new List<UnitCategoryDto>();
        }

        public UnitCategoryDto Unit { get; set; }

        public List<UnitCategoryDto> Details { get; set; }
    }
}
