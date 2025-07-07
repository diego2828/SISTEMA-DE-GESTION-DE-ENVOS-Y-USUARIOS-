using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class NuevaRelacionComunAgencia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Envios_Agencias_AgenciaId",
                table: "Envios");

            migrationBuilder.AddForeignKey(
                name: "FK_Envios_Agencias_AgenciaId",
                table: "Envios",
                column: "AgenciaId",
                principalTable: "Agencias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Envios_Agencias_AgenciaId",
                table: "Envios");

            migrationBuilder.AddForeignKey(
                name: "FK_Envios_Agencias_AgenciaId",
                table: "Envios",
                column: "AgenciaId",
                principalTable: "Agencias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
