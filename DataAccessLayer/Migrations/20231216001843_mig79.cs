using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig79 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EmotionResults",
                table: "EmotionResults");

            migrationBuilder.DropColumn(
                name: "Emotion",
                table: "Posts");

            migrationBuilder.RenameTable(
                name: "EmotionResults",
                newName: "EmotionResult");

            migrationBuilder.AddColumn<string>(
                name: "EmotionResultId",
                table: "Posts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmotionResult",
                table: "EmotionResult",
                column: "EmotionResultId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_EmotionResultId",
                table: "Posts",
                column: "EmotionResultId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_EmotionResult_EmotionResultId",
                table: "Posts",
                column: "EmotionResultId",
                principalTable: "EmotionResult",
                principalColumn: "EmotionResultId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_EmotionResult_EmotionResultId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_EmotionResultId",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmotionResult",
                table: "EmotionResult");

            migrationBuilder.DropColumn(
                name: "EmotionResultId",
                table: "Posts");

            migrationBuilder.RenameTable(
                name: "EmotionResult",
                newName: "EmotionResults");

            migrationBuilder.AddColumn<string>(
                name: "Emotion",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmotionResults",
                table: "EmotionResults",
                column: "EmotionResultId");
        }
    }
}
