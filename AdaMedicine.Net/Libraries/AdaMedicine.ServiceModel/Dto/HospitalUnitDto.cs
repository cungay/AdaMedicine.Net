using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AdaMedicine.ServiceModel.Dto
{
    public class HospitalUnitDto
    {
        public HospitalUnitDto()
        {
            this.Category = new UnitCategoryDto();
            this.Units = new List<UnitCategoryDto>();
        }

        public UnitCategoryDto Category { get; set; }

        public List<UnitCategoryDto> Units { get; set; }
    }
}
