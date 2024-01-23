#nullable disable

namespace Orchestrator.Database.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;
    using System;

    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InstancesToPoll",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuoteId = table.Column<int>(type: "int", nullable: false),
                    ApplicationId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    InstanceId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeterministicHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstancesToPoll", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InstancesToPoll_ApplicationId",
                table: "InstancesToPoll",
                column: "ApplicationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InstancesToPoll");
        }
    }
}
