using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class AgregoRelacionAuditoriaUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auditoria_Usuarios_UsuarioId",
                table: "Auditoria");

            migrationBuilder.AddForeignKey(
                name: "FK_Auditoria_Usuarios_UsuarioId",
                table: "Auditoria",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auditoria_Usuarios_UsuarioId",
                table: "Auditoria");

            migrationBuilder.AddForeignKey(
                name: "FK_Auditoria_Usuarios_UsuarioId",
                table: "Auditoria",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
