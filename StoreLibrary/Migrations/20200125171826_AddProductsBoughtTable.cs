using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreLibrary.Migrations
{
    public partial class AddProductsBoughtTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Purchases_PurchasesId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_PurchasesId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PurchasesId",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "ProductsBoughts",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoeID = table.Column<string>(maxLength: 50, nullable: false),
                    ShoeName = table.Column<string>(maxLength: 50, nullable: true),
                    ShoePrice = table.Column<string>(maxLength: 10, nullable: true),
                    QuantityBought = table.Column<int>(nullable: false),
                    PurchasesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsBoughts", x => x.id);
                    table.ForeignKey(
                        name: "FK_ProductsBoughts_Purchases_PurchasesId",
                        column: x => x.PurchasesId,
                        principalTable: "Purchases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductsBoughts_PurchasesId",
                table: "ProductsBoughts",
                column: "PurchasesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductsBoughts");

            migrationBuilder.AddColumn<int>(
                name: "PurchasesId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_PurchasesId",
                table: "Products",
                column: "PurchasesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Purchases_PurchasesId",
                table: "Products",
                column: "PurchasesId",
                principalTable: "Purchases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
