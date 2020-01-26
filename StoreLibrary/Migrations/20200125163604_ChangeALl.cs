using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreLibrary.Migrations
{
    public partial class ChangeALl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Purchases_PurchasesPurchaseID",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Requests_SupportRequestsSupportRequestId",
                table: "Purchases");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItems_Purchases_PurchasesPurchaseID",
                table: "ShoppingCartItems");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCartItems_PurchasesPurchaseID",
                table: "ShoppingCartItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Requests",
                table: "Requests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Purchases",
                table: "Purchases");

            migrationBuilder.DropIndex(
                name: "IX_Purchases_SupportRequestsSupportRequestId",
                table: "Purchases");

            migrationBuilder.DropIndex(
                name: "IX_Products_PurchasesPurchaseID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PurchasesPurchaseID",
                table: "ShoppingCartItems");

            migrationBuilder.DropColumn(
                name: "SupportRequestId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "PurchaseID",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "SupportRequestsSupportRequestId",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "PurchasesPurchaseID",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Requests",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Purchases",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "SupportRequestsId",
                table: "Purchases",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PurchasesId",
                table: "Products",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Requests",
                table: "Requests",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Purchases",
                table: "Purchases",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_SupportRequestsId",
                table: "Purchases",
                column: "SupportRequestsId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Requests_SupportRequestsId",
                table: "Purchases",
                column: "SupportRequestsId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Purchases_PurchasesId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Requests_SupportRequestsId",
                table: "Purchases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Requests",
                table: "Requests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Purchases",
                table: "Purchases");

            migrationBuilder.DropIndex(
                name: "IX_Purchases_SupportRequestsId",
                table: "Purchases");

            migrationBuilder.DropIndex(
                name: "IX_Products_PurchasesId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "SupportRequestsId",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "PurchasesId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "PurchasesPurchaseID",
                table: "ShoppingCartItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SupportRequestId",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "PurchaseID",
                table: "Purchases",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "SupportRequestsSupportRequestId",
                table: "Purchases",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PurchasesPurchaseID",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Requests",
                table: "Requests",
                column: "SupportRequestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Purchases",
                table: "Purchases",
                column: "PurchaseID");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_PurchasesPurchaseID",
                table: "ShoppingCartItems",
                column: "PurchasesPurchaseID");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_SupportRequestsSupportRequestId",
                table: "Purchases",
                column: "SupportRequestsSupportRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_PurchasesPurchaseID",
                table: "Products",
                column: "PurchasesPurchaseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Purchases_PurchasesPurchaseID",
                table: "Products",
                column: "PurchasesPurchaseID",
                principalTable: "Purchases",
                principalColumn: "PurchaseID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Requests_SupportRequestsSupportRequestId",
                table: "Purchases",
                column: "SupportRequestsSupportRequestId",
                principalTable: "Requests",
                principalColumn: "SupportRequestId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItems_Purchases_PurchasesPurchaseID",
                table: "ShoppingCartItems",
                column: "PurchasesPurchaseID",
                principalTable: "Purchases",
                principalColumn: "PurchaseID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
