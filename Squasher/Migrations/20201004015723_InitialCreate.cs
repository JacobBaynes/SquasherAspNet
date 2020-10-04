using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Squasher.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Squasher",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Squasher", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Bug",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Severity = table.Column<string>(nullable: true),
                    Version = table.Column<string>(nullable: true),
                    TrackDate = table.Column<DateTime>(nullable: false),
                    ProjectID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bug", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Bug_Project_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Project",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectSquasherModel",
                columns: table => new
                {
                    ProjectId = table.Column<int>(nullable: false),
                    SquasherId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectSquasherModel", x => new { x.ProjectId, x.SquasherId });
                    table.ForeignKey(
                        name: "FK_ProjectSquasherModel_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectSquasherModel_Squasher_SquasherId",
                        column: x => x.SquasherId,
                        principalTable: "Squasher",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BugSquasherModel",
                columns: table => new
                {
                    BugId = table.Column<int>(nullable: false),
                    SquasherId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BugSquasherModel", x => new { x.BugId, x.SquasherId });
                    table.ForeignKey(
                        name: "FK_BugSquasherModel_Bug_BugId",
                        column: x => x.BugId,
                        principalTable: "Bug",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BugSquasherModel_Squasher_SquasherId",
                        column: x => x.SquasherId,
                        principalTable: "Squasher",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bug_ProjectID",
                table: "Bug",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_BugSquasherModel_SquasherId",
                table: "BugSquasherModel",
                column: "SquasherId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSquasherModel_SquasherId",
                table: "ProjectSquasherModel",
                column: "SquasherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BugSquasherModel");

            migrationBuilder.DropTable(
                name: "ProjectSquasherModel");

            migrationBuilder.DropTable(
                name: "Bug");

            migrationBuilder.DropTable(
                name: "Squasher");

            migrationBuilder.DropTable(
                name: "Project");
        }
    }
}
