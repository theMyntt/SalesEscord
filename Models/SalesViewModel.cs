using SalesEscord.Models.Persistance;

namespace SalesEscord.Models
{
    public class SalesViewModel
    {
        public IEnumerable<SalesModel> Sales { get; set; } = [];
        public int TotalPages { get; set; }
        public int Page { get; set; }
        public int TotalSales { get; set; }
    }
}
