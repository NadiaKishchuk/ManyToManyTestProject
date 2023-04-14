using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tests.Migrations.ContextWihtEntityMigrations
{
    /// <inheritdoc />
    public partial class inititalWithEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Partners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Streetcodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Streetcodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "streetcode_partners",
                columns: table => new
                {
                    PartnersId = table.Column<int>(type: "int", nullable: false),
                    StreetcodesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_streetcode_partners", x => new { x.PartnersId, x.StreetcodesId });
                    table.ForeignKey(
                        name: "FK_streetcode_partners_Partners_PartnersId",
                        column: x => x.PartnersId,
                        principalTable: "Partners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_streetcode_partners_Streetcodes_StreetcodesId",
                        column: x => x.StreetcodesId,
                        principalTable: "Streetcodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_streetcode_partners_StreetcodesId",
                table: "streetcode_partners",
                column: "StreetcodesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "streetcode_partners");

            migrationBuilder.DropTable(
                name: "Partners");

            migrationBuilder.DropTable(
                name: "Streetcodes");
        }
    }
}
