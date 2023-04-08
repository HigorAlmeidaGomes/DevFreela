using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DevFreela.Infrastructure.Persistence.Migrations
{
    public partial class InitialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_SKILL",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_SKILL", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_USER",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USER", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_PROJECT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdClient = table.Column<int>(type: "int", nullable: false),
                    IdFreelancer = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinishedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PROJECT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_PROJECT_TB_USER_IdClient",
                        column: x => x.IdClient,
                        principalTable: "TB_USER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_PROJECT_TB_USER_IdFreelancer",
                        column: x => x.IdFreelancer,
                        principalTable: "TB_USER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_USERSKILL",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    IdSkill = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USERSKILL", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_USERSKILL_TB_USER_IdSkill",
                        column: x => x.IdSkill,
                        principalTable: "TB_USER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_PROJECTCOMMENT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdProject = table.Column<int>(type: "int", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PROJECTCOMMENT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_PROJECTCOMMENT_TB_PROJECT_IdProject",
                        column: x => x.IdProject,
                        principalTable: "TB_PROJECT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_PROJECTCOMMENT_TB_USER_IdUser",
                        column: x => x.IdUser,
                        principalTable: "TB_USER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_PROJECT_IdClient",
                table: "TB_PROJECT",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PROJECT_IdFreelancer",
                table: "TB_PROJECT",
                column: "IdFreelancer");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PROJECTCOMMENT_IdProject",
                table: "TB_PROJECTCOMMENT",
                column: "IdProject");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PROJECTCOMMENT_IdUser",
                table: "TB_PROJECTCOMMENT",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_TB_USERSKILL_IdSkill",
                table: "TB_USERSKILL",
                column: "IdSkill");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_PROJECTCOMMENT");

            migrationBuilder.DropTable(
                name: "TB_SKILL");

            migrationBuilder.DropTable(
                name: "TB_USERSKILL");

            migrationBuilder.DropTable(
                name: "TB_PROJECT");

            migrationBuilder.DropTable(
                name: "TB_USER");
        }
    }
}
