using Microsoft.EntityFrameworkCore.Migrations;

namespace CSprojectP3.Migrations
{
    public partial class createdb7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transactionItems_Orders_OrderID",
                table: "transactionItems");

            migrationBuilder.AlterColumn<int>(
                name: "OrderID",
                table: "transactionItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_transactionItems_Orders_OrderID",
                table: "transactionItems",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transactionItems_Orders_OrderID",
                table: "transactionItems");

            migrationBuilder.AlterColumn<int>(
                name: "OrderID",
                table: "transactionItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_transactionItems_Orders_OrderID",
                table: "transactionItems",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
