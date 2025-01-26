using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesEscord.Models.Persistance
{
    [Table("TBL_SALES")]
    public class SalesModel
    {
        [Key]
        [Column("ID_SALE")]
        public Guid Id { get; set; }

        [Column("TX_PRODUCT_NAME")]
        public string ProductName { get; set; } = string.Empty;

        [Column("TX_FINAL_PRICE")]
        public double FinalPrice { get; set; }

        [Column("TX_DATE_OF_SALE")]
        public DateTime SoldOn { get; set; }
    }
}
