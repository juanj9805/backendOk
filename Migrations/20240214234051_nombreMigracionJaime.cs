using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProfeTours.Server.Migrations
{
    public partial class nombreMigracionJaime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Paquetes",
                columns: table => new
                {
                    IdPaquete = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImagenPaquete = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombrePaquete = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescripcionPaquete = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrecioPaquete = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DestinoPaquete = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaSalida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaRegreso = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paquetes", x => x.IdPaquete);
                });

            migrationBuilder.CreateTable(
                name: "TipoDocumentos",
                columns: table => new
                {
                    IdTipoDocumento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoDocumentoNombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDocumentos", x => x.IdTipoDocumento);
                });

            migrationBuilder.CreateTable(
                name: "Tiporoles",
                columns: table => new
                {
                    IdTipoRoles = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoRoles = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tiporoles", x => x.IdTipoRoles);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTipoDocumento = table.Column<int>(type: "int", nullable: false),
                    NumeroDocumento = table.Column<int>(type: "int", nullable: false),
                    NombreCompleto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DireccionDomicilio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroTelefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.IdCliente);
                    table.ForeignKey(
                        name: "FK_Clientes_TipoDocumentos_IdTipoDocumento",
                        column: x => x.IdTipoDocumento,
                        principalTable: "TipoDocumentos",
                        principalColumn: "IdTipoDocumento",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroDocumento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contrasena = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdTipoRole = table.Column<int>(type: "int", nullable: false),
                    IdTipoDocumento = table.Column<int>(type: "int", nullable: false),
                    TiporoleIdTipoRoles1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_TipoDocumentos_IdTipoDocumento",
                        column: x => x.IdTipoDocumento,
                        principalTable: "TipoDocumentos",
                        principalColumn: "IdTipoDocumento",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuarios_Tiporoles_IdTipoRole",
                        column: x => x.IdTipoRole,
                        principalTable: "Tiporoles",
                        principalColumn: "IdTipoRoles",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuarios_Tiporoles_TiporoleIdTipoRoles1",
                        column: x => x.TiporoleIdTipoRoles1,
                        principalTable: "Tiporoles",
                        principalColumn: "IdTipoRoles");
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    IdVenta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    IdPaquete = table.Column<int>(type: "int", nullable: false),
                    FechaCompra = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.IdVenta);
                    table.ForeignKey(
                        name: "FK_Ventas_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ventas_Paquetes_IdPaquete",
                        column: x => x.IdPaquete,
                        principalTable: "Paquetes",
                        principalColumn: "IdPaquete",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_IdTipoDocumento",
                table: "Clientes",
                column: "IdTipoDocumento");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdTipoDocumento",
                table: "Usuarios",
                column: "IdTipoDocumento");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdTipoRole",
                table: "Usuarios",
                column: "IdTipoRole");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_TiporoleIdTipoRoles1",
                table: "Usuarios",
                column: "TiporoleIdTipoRoles1");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_IdCliente",
                table: "Ventas",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_IdPaquete",
                table: "Ventas",
                column: "IdPaquete");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "Tiporoles");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Paquetes");

            migrationBuilder.DropTable(
                name: "TipoDocumentos");
        }
    }
}
