using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CR_YPTO_TPF.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "alerta",
                columns: table => new
                {
                    idUsuario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    idCrypto = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    umbralAlerta = table.Column<double>(type: "float", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("alerta_pkey", x => new { x.idUsuario, x.idCrypto });
                });

            migrationBuilder.CreateTable(
                name: "cryptohistoria",
                columns: table => new
                {
                    idcryptohistoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idUsuario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    idCrypto = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    precio = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PriceUSD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("cryptohistoria_pkey", x => x.idcryptohistoria);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    idUsuario = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    apellido = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    correo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    clave = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    umbral = table.Column<double>(type: "float", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("usuario_pk", x => x.idUsuario);
                });

            migrationBuilder.CreateTable(
                name: "usuarioCrypto",
                columns: table => new
                {
                    IdUsuario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdCrypto = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    usuarioidUsuario = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("usuarioCrypto_pkey", x => new { x.IdUsuario, x.IdCrypto });
                    table.ForeignKey(
                        name: "FK_usuarioCrypto_usuario_usuarioidUsuario",
                        column: x => x.usuarioidUsuario,
                        principalTable: "usuario",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_usuarioCrypto_usuarioidUsuario",
                table: "usuarioCrypto",
                column: "usuarioidUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "alerta");

            migrationBuilder.DropTable(
                name: "cryptohistoria");

            migrationBuilder.DropTable(
                name: "usuarioCrypto");

            migrationBuilder.DropTable(
                name: "usuario");
        }
    }
}
