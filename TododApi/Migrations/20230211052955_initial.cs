using Microsoft.EntityFrameworkCore.Migrations;

namespace TododApi.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    userId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    username = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.userId);
                });

            migrationBuilder.CreateTable(
                name: "TodoList",
                columns: table => new
                {
                    todoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    userId = table.Column<int>(type: "INTEGER", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: true),
                    done = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoList", x => x.todoId);
                    table.ForeignKey(
                        name: "FK_TodoList_User_userId",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "userId", "username" },
                values: new object[] { 1, "patrickStar2023" });

            migrationBuilder.InsertData(
                table: "TodoList",
                columns: new[] { "todoId", "description", "done", "userId" },
                values: new object[] { 1, "Sleep under my rock", false, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_TodoList_userId",
                table: "TodoList",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TodoList");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
