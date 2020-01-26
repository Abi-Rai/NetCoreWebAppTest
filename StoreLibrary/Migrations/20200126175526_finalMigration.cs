using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreLibrary.Migrations
{
    public partial class finalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShoesMatched",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoeIdMatch = table.Column<string>(maxLength: 50, nullable: true),
                    SelectPromoProductId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoesMatched", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoesMatched_Products_SelectPromoProductId",
                        column: x => x.SelectPromoProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoesMatched_SelectPromoProductId",
                table: "ShoesMatched",
                column: "SelectPromoProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoesMatched");
        }
    }
}
