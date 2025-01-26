using System.ComponentModel.DataAnnotations;

namespace SalesEscord.DTOs
{
    public class FindSalesDTO
    {
        [Range(1, int.MaxValue)]
        public int Page { get; set; } = 1;

        [Range(1, 100)]
        public int Limit { get; set; } = 10;
    }
}
