using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Asp.net_core_api.Migrations
{
    /// <inheritdoc />
    public partial class passeneger : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "passengers",
                columns: table => new
                {
                    Pass_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pass_PhoneNumber = table.Column<long>(type: "bigint", nullable: false),
                    Pass_Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pass_FristName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pass_SecondName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pass_LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pass_GenderM = table.Column<int>(type: "int", nullable: true),
                    Pass_BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Pass_Rank = table.Column<short>(type: "smallint", nullable: true),
                    Pass_Rating = table.Column<byte>(type: "tinyint", nullable: true),
                    Pass_Balance = table.Column<int>(type: "int", nullable: true),
                    Pass_Flags = table.Column<short>(type: "smallint", nullable: false),
                    Pass_Status = table.Column<byte>(type: "tinyint", nullable: false),
                    Pass_languge = table.Column<byte>(type: "tinyint", nullable: false),
                    email_verified_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_passengers", x => x.Pass_ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "passengers");
        }
    }
}
