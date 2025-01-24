using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesEscord.Models.Persistance
{
    [Table("TBL_USERS")]
    public class UserModel
    {
        [Key]
        [Column("ID_USER")]
        public Guid Id { get; set; }

        [Column("TX_NAME")]
        public string Name { get; set; } = string.Empty;

        [Column("TX_EMAIL")]
        public string Email { get; set; } = string.Empty;

        [Column("TX_PASSWORD")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Column("TX_ROLE")]
        public string Role { get; set; } = string.Empty;

        [Column("TX_IS_BLOCKER")]
        public bool IsBlocked { get; set; }

        [Column("TX_REGISTERED_AT")]
        public DateTime CreatedAt { get; set; }

        [Column("TX_LAST_UPDATE")]
        public DateTime? UpdatedAt { get; set; }
    }
}
