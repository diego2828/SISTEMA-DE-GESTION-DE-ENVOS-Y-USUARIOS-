using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class TPH_EnvioComunUrgente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AgenciaId",
                table: "Envios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DireccionPostalEspecifica",
                table: "Envios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Envios",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "EntregaEficiente",
                table: "Envios",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TiempoLLegada",
                table: "Envios",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TiempoSalida",
                table: "Envios",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Envios_AgenciaId",
                table: "Envios",
                column: "AgenciaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Envios_Agencias_AgenciaId",
                table: "Envios",
                column: "AgenciaId",
                principalTable: "Agencias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Envios_Agencias_AgenciaId",
                table: "Envios");

            migrationBuilder.DropIndex(
                name: "IX_Envios_AgenciaId",
                table: "Envios");

            migrationBuilder.DropColumn(
                name: "AgenciaId",
                table: "Envios");

            migrationBuilder.DropColumn(
                name: "DireccionPostalEspecifica",
                table: "Envios");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Envios");

            migrationBuilder.DropColumn(
                name: "EntregaEficiente",
                table: "Envios");

            migrationBuilder.DropColumn(
                name: "TiempoLLegada",
                table: "Envios");

            migrationBuilder.DropColumn(
                name: "TiempoSalida",
                table: "Envios");
        }
    }
}
