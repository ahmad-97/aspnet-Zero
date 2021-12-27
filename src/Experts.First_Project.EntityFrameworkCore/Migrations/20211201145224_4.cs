using Microsoft.EntityFrameworkCore.Migrations;

namespace Experts.First_Project.Migrations
{
    public partial class _4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descriprtion",
                table: "TestEntities",
                newName: "Description");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "TestEntities",
                newName: "Descriprtion");
        }
    }
}
