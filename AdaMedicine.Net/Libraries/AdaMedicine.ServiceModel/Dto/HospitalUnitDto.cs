using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AdaMedicine.ServiceModel.Dto
{
    [DataContract]
    public class HospitalUnitDto
    {
        public HospitalUnitDto()
        {
            this.Category = new UnitCategoryDto();
            this.Units = new List<UnitCategoryDto>();
        }

        [DataMember]
        public UnitCategoryDto Category { get; set; }

        [DataMember]
        public List<UnitCategoryDto> Units { get; set; }
    }
}
