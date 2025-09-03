using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NiftyCoders.Services.TraineeManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class TrainingPeriodForeignKeyAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainee_TrainningPeriod_TrainningPeriodId",
                table: "Trainees");

            migrationBuilder.CreateIndex(
                name: "IX_Trainees_TrainningPeriodId",
                table: "Trainees",
                column: "TrainningPeriodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainee_TrainningPeriod_TrainningPeriodId",
                table: "Trainees",
                column: "TrainningPeriodId",
                principalTable: "TrainningPeriod",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainee_TrainningPeriod_TrainningPeriodId",
                table: "Trainees");

            migrationBuilder.DropIndex(
                name: "IX_Trainees_TrainningPeriodId",
                table: "Trainees");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainee_TrainningPeriod_TrainningPeriodId",
                table: "Trainees",
                column: "UniversityId",
                principalTable: "TrainningPeriod",
                principalColumn: "Id");
        }
    }
}
