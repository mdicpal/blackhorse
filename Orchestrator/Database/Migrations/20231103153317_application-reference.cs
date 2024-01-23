using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Orchestrator.Database.Migrations
{
    public partial class applicationreference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "InstancesToPoll",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProposalId",
                table: "InstancesToPoll",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "InstancesToPoll");

            migrationBuilder.DropColumn(
                name: "ProposalId",
                table: "InstancesToPoll");
        }
    }
}
