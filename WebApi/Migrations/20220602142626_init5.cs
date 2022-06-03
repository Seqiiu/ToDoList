using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class init5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_StatusOfTask_StatusId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_User2_User2Id",
                table: "Tasks");

            migrationBuilder.AlterColumn<int>(
                name: "User2Id",
                table: "Tasks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Tasks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_StatusOfTask_StatusId",
                table: "Tasks",
                column: "StatusId",
                principalTable: "StatusOfTask",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_User2_User2Id",
                table: "Tasks",
                column: "User2Id",
                principalTable: "User2",
                principalColumn: "User2Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_StatusOfTask_StatusId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_User2_User2Id",
                table: "Tasks");

            migrationBuilder.AlterColumn<int>(
                name: "User2Id",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_StatusOfTask_StatusId",
                table: "Tasks",
                column: "StatusId",
                principalTable: "StatusOfTask",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_User2_User2Id",
                table: "Tasks",
                column: "User2Id",
                principalTable: "User2",
                principalColumn: "User2Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
