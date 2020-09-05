using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoPhoneBook.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "ToDoItem",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ItemType = table.Column<int>(nullable: false),
            //        Title = table.Column<string>(nullable: true),
            //        StartDate = table.Column<DateTime>(nullable: true),
            //        EndDate = table.Column<DateTime>(nullable: true),
            //        Place = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ToDoItem", x => x.Id);
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDoItem");
        }
    }
}
