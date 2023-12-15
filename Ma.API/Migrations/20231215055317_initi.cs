using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Ma.API.Migrations
{
    /// <inheritdoc />
    public partial class initi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lawyers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Cpf = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    Oab = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lawyers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lawyers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Registries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true),
                    LawyerResponsibleId = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Registries_Lawyers_LawyerResponsibleId",
                        column: x => x.LawyerResponsibleId,
                        principalTable: "Lawyers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Lawsuits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LawsuitCode = table.Column<string>(type: "text", nullable: false),
                    Subject = table.Column<string>(type: "text", nullable: false),
                    Observation = table.Column<string>(type: "text", nullable: false),
                    LawsuitClientPosition = table.Column<int>(type: "integer", nullable: false),
                    LawsuitType = table.Column<int>(type: "integer", nullable: false),
                    ResponsibleLawyerId = table.Column<int>(type: "integer", nullable: false),
                    AdversePartId = table.Column<int>(type: "integer", nullable: false),
                    ClientId = table.Column<int>(type: "integer", nullable: false),
                    IndicatedById = table.Column<int>(type: "integer", nullable: true),
                    InitialDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FinalDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lawsuits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lawsuits_Lawyers_ResponsibleLawyerId",
                        column: x => x.ResponsibleLawyerId,
                        principalTable: "Lawyers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lawsuits_Registries_AdversePartId",
                        column: x => x.AdversePartId,
                        principalTable: "Registries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lawsuits_Registries_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Registries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lawsuits_Registries_IndicatedById",
                        column: x => x.IndicatedById,
                        principalTable: "Registries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LawsuitFees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Referent = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<double>(type: "double precision", nullable: false),
                    IsGain = table.Column<bool>(type: "boolean", nullable: false),
                    LawsuitId = table.Column<int>(type: "integer", nullable: false),
                    LawyerId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LawsuitFees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LawsuitFees_Lawsuits_LawsuitId",
                        column: x => x.LawsuitId,
                        principalTable: "Lawsuits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LawsuitFees_Lawyers_LawyerId",
                        column: x => x.LawyerId,
                        principalTable: "Lawyers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LawsuitFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FileName = table.Column<string>(type: "text", nullable: false),
                    FileUrl = table.Column<string>(type: "text", nullable: false),
                    LawsuitId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LawsuitFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LawsuitFiles_Lawsuits_LawsuitId",
                        column: x => x.LawsuitId,
                        principalTable: "Lawsuits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LawsuitFees_LawsuitId",
                table: "LawsuitFees",
                column: "LawsuitId");

            migrationBuilder.CreateIndex(
                name: "IX_LawsuitFees_LawyerId",
                table: "LawsuitFees",
                column: "LawyerId");

            migrationBuilder.CreateIndex(
                name: "IX_LawsuitFiles_LawsuitId",
                table: "LawsuitFiles",
                column: "LawsuitId");

            migrationBuilder.CreateIndex(
                name: "IX_Lawsuits_AdversePartId",
                table: "Lawsuits",
                column: "AdversePartId");

            migrationBuilder.CreateIndex(
                name: "IX_Lawsuits_ClientId",
                table: "Lawsuits",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Lawsuits_IndicatedById",
                table: "Lawsuits",
                column: "IndicatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Lawsuits_ResponsibleLawyerId",
                table: "Lawsuits",
                column: "ResponsibleLawyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Lawyers_UserId",
                table: "Lawyers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Registries_LawyerResponsibleId",
                table: "Registries",
                column: "LawyerResponsibleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LawsuitFees");

            migrationBuilder.DropTable(
                name: "LawsuitFiles");

            migrationBuilder.DropTable(
                name: "Lawsuits");

            migrationBuilder.DropTable(
                name: "Registries");

            migrationBuilder.DropTable(
                name: "Lawyers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
