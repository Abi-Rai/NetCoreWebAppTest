using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreLibrary.Migrations
{
    public partial class ChangedLots : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Requests_SupportRequestsId",
                table: "Purchases");

            migrationBuilder.DropIndex(
                name: "IX_Purchases_SupportRequestsId",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "SupportRequestsId",
                table: "Purchases");

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "Requests",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ForShoeID",
                table: "Requests",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OrderId",
                table: "Requests",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Reason",
                table: "Requests",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "ShoePrice",
                table: "ProductsBoughts",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ShoeName",
                table: "ProductsBoughts",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrderIDref",
                table: "ProductsBoughts",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ForShoeID",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Reason",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "OrderIDref",
                table: "ProductsBoughts");

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "Requests",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 150);

            migrationBuilder.AddColumn<int>(
                name: "SupportRequestsId",
                table: "Purchases",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ShoePrice",
                table: "ProductsBoughts",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "ShoeName",
                table: "ProductsBoughts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_SupportRequestsId",
                table: "Purchases",
                column: "SupportRequestsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Requests_SupportRequestsId",
                table: "Purchases",
                column: "SupportRequestsId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
