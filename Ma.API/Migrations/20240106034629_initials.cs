using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ma.API.Migrations
{
    /// <inheritdoc />
    public partial class initials : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lawsuits_Lawyers_ResponsibleLawyerEntityId",
                table: "Lawsuits");

            migrationBuilder.DropIndex(
                name: "IX_Lawsuits_ResponsibleLawyerEntityId",
                table: "Lawsuits");

            migrationBuilder.DropColumn(
                name: "ResponsibleLawyerEntityId",
                table: "Lawsuits");

            migrationBuilder.CreateIndex(
                name: "IX_Lawsuits_ResponsibleLawyerId",
                table: "Lawsuits",
                column: "ResponsibleLawyerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lawsuits_Lawyers_ResponsibleLawyerId",
                table: "Lawsuits",
                column: "ResponsibleLawyerId",
                principalTable: "Lawyers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lawsuits_Lawyers_ResponsibleLawyerId",
                table: "Lawsuits");

            migrationBuilder.DropIndex(
                name: "IX_Lawsuits_ResponsibleLawyerId",
                table: "Lawsuits");

            migrationBuilder.AddColumn<int>(
                name: "ResponsibleLawyerEntityId",
                table: "Lawsuits",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Lawsuits_ResponsibleLawyerEntityId",
                table: "Lawsuits",
                column: "ResponsibleLawyerEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lawsuits_Lawyers_ResponsibleLawyerEntityId",
                table: "Lawsuits",
                column: "ResponsibleLawyerEntityId",
                principalTable: "Lawyers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
