using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesEscord.Migrations
{
    /// <inheritdoc />
    public partial class UsersTableMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBL_USERS",
                columns: table => new
                {
                    ID_USER = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TX_NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TX_EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TX_PASSWORD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TX_ROLE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TX_IS_BLOCKER = table.Column<bool>(type: "bit", nullable: false),
                    TX_REGISTERED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TX_LAST_UPDATE = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_USERS", x => x.ID_USER);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_USERS");
        }
    }
}
