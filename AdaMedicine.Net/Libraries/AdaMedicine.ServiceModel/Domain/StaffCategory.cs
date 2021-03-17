using Ege.Net.Data;

namespace AdaMedicine.ServiceModel.Domain
{
    public class StaffCategory : IEntity<int>
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public string ShortName { get; set; }
    }
}
