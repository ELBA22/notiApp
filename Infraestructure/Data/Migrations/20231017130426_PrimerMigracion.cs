using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class PrimerMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Auditorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreUsuario = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DesAccion = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auditorias", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EstadoNotificaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreEstado = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoNotificaciones", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Formatos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreFormato = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formatos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HilosRepuestas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreTipo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HilosRepuestas", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ModulosMaestros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreModulo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModulosMaestros", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PermisosGenericos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombrPermiso = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermisosGenericos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Radicados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Radicados", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Submodulos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreSubModulo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Submodulos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TipoNotificaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreTipo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoNotificaciones", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TipoRequerimientos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoRequerimientos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RolesvsMaestros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RolesId = table.Column<int>(type: "int", nullable: true),
                    IdRol = table.Column<int>(type: "int", nullable: false),
                    ModulosMaestrosId = table.Column<int>(type: "int", nullable: true),
                    IdMMaestro = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesvsMaestros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolesvsMaestros_ModulosMaestros_ModulosMaestrosId",
                        column: x => x.ModulosMaestrosId,
                        principalTable: "ModulosMaestros",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RolesvsMaestros_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MaestrosvsSubmodulos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ModulosMaestrosId = table.Column<int>(type: "int", nullable: true),
                    IdModuloMaestro = table.Column<int>(type: "int", nullable: false),
                    SubmodulosId = table.Column<int>(type: "int", nullable: true),
                    IdSubmodulo = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaestrosvsSubmodulos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaestrosvsSubmodulos_ModulosMaestros_ModulosMaestrosId",
                        column: x => x.ModulosMaestrosId,
                        principalTable: "ModulosMaestros",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MaestrosvsSubmodulos_Submodulos_SubmodulosId",
                        column: x => x.SubmodulosId,
                        principalTable: "Submodulos",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BlockChains",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    hashGenerado = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HilosRespuestasId = table.Column<int>(type: "int", nullable: true),
                    IdHiloRespu = table.Column<int>(type: "int", nullable: false),
                    AuditoriasId = table.Column<int>(type: "int", nullable: true),
                    IdAuditoria = table.Column<int>(type: "int", nullable: false),
                    TipoNotificacionesId = table.Column<int>(type: "int", nullable: true),
                    IdTipoNotificacion = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlockChains", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlockChains_Auditorias_AuditoriasId",
                        column: x => x.AuditoriasId,
                        principalTable: "Auditorias",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BlockChains_HilosRepuestas_HilosRespuestasId",
                        column: x => x.HilosRespuestasId,
                        principalTable: "HilosRepuestas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BlockChains_TipoNotificaciones_TipoNotificacionesId",
                        column: x => x.TipoNotificacionesId,
                        principalTable: "TipoNotificaciones",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ModulosNotificaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AsuntoNotificacion = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoNotificacionesId = table.Column<int>(type: "int", nullable: true),
                    IdTipoNotificacion = table.Column<int>(type: "int", nullable: false),
                    RadicadosId = table.Column<int>(type: "int", nullable: true),
                    IdRadicado = table.Column<int>(type: "int", nullable: false),
                    EstadosvsNotificacionesId = table.Column<int>(type: "int", nullable: true),
                    IdEstadoNotificacion = table.Column<int>(type: "int", nullable: false),
                    HiloRespuestasId = table.Column<int>(type: "int", nullable: true),
                    IdHiloRespu = table.Column<int>(type: "int", nullable: false),
                    FormatosId = table.Column<int>(type: "int", nullable: true),
                    IdFormato = table.Column<int>(type: "int", nullable: false),
                    TiposRequerimientosId = table.Column<int>(type: "int", nullable: true),
                    IdTipoRequerimiento = table.Column<int>(type: "int", nullable: false),
                    TextoNotificacion = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModulosNotificaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModulosNotificaciones_EstadoNotificaciones_EstadosvsNotifica~",
                        column: x => x.EstadosvsNotificacionesId,
                        principalTable: "EstadoNotificaciones",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ModulosNotificaciones_Formatos_FormatosId",
                        column: x => x.FormatosId,
                        principalTable: "Formatos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ModulosNotificaciones_HilosRepuestas_HiloRespuestasId",
                        column: x => x.HiloRespuestasId,
                        principalTable: "HilosRepuestas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ModulosNotificaciones_Radicados_RadicadosId",
                        column: x => x.RadicadosId,
                        principalTable: "Radicados",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ModulosNotificaciones_TipoNotificaciones_TipoNotificacionesId",
                        column: x => x.TipoNotificacionesId,
                        principalTable: "TipoNotificaciones",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ModulosNotificaciones_TipoRequerimientos_TiposRequerimientos~",
                        column: x => x.TiposRequerimientosId,
                        principalTable: "TipoRequerimientos",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "GenericosvsSubmodulos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PermisosGenericosId = table.Column<int>(type: "int", nullable: true),
                    IdPermisoGenerico = table.Column<int>(type: "int", nullable: false),
                    MaestrosvsSubmodulosId = table.Column<int>(type: "int", nullable: true),
                    IdMaestrovsSubmodulos = table.Column<int>(type: "int", nullable: false),
                    RolesId = table.Column<int>(type: "int", nullable: true),
                    IdRoles = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenericosvsSubmodulos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GenericosvsSubmodulos_MaestrosvsSubmodulos_MaestrosvsSubmodu~",
                        column: x => x.MaestrosvsSubmodulosId,
                        principalTable: "MaestrosvsSubmodulos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GenericosvsSubmodulos_PermisosGenericos_PermisosGenericosId",
                        column: x => x.PermisosGenericosId,
                        principalTable: "PermisosGenericos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GenericosvsSubmodulos_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_BlockChains_AuditoriasId",
                table: "BlockChains",
                column: "AuditoriasId");

            migrationBuilder.CreateIndex(
                name: "IX_BlockChains_HilosRespuestasId",
                table: "BlockChains",
                column: "HilosRespuestasId");

            migrationBuilder.CreateIndex(
                name: "IX_BlockChains_TipoNotificacionesId",
                table: "BlockChains",
                column: "TipoNotificacionesId");

            migrationBuilder.CreateIndex(
                name: "IX_GenericosvsSubmodulos_MaestrosvsSubmodulosId",
                table: "GenericosvsSubmodulos",
                column: "MaestrosvsSubmodulosId");

            migrationBuilder.CreateIndex(
                name: "IX_GenericosvsSubmodulos_PermisosGenericosId",
                table: "GenericosvsSubmodulos",
                column: "PermisosGenericosId");

            migrationBuilder.CreateIndex(
                name: "IX_GenericosvsSubmodulos_RolesId",
                table: "GenericosvsSubmodulos",
                column: "RolesId");

            migrationBuilder.CreateIndex(
                name: "IX_MaestrosvsSubmodulos_ModulosMaestrosId",
                table: "MaestrosvsSubmodulos",
                column: "ModulosMaestrosId");

            migrationBuilder.CreateIndex(
                name: "IX_MaestrosvsSubmodulos_SubmodulosId",
                table: "MaestrosvsSubmodulos",
                column: "SubmodulosId");

            migrationBuilder.CreateIndex(
                name: "IX_ModulosNotificaciones_EstadosvsNotificacionesId",
                table: "ModulosNotificaciones",
                column: "EstadosvsNotificacionesId");

            migrationBuilder.CreateIndex(
                name: "IX_ModulosNotificaciones_FormatosId",
                table: "ModulosNotificaciones",
                column: "FormatosId");

            migrationBuilder.CreateIndex(
                name: "IX_ModulosNotificaciones_HiloRespuestasId",
                table: "ModulosNotificaciones",
                column: "HiloRespuestasId");

            migrationBuilder.CreateIndex(
                name: "IX_ModulosNotificaciones_RadicadosId",
                table: "ModulosNotificaciones",
                column: "RadicadosId");

            migrationBuilder.CreateIndex(
                name: "IX_ModulosNotificaciones_TipoNotificacionesId",
                table: "ModulosNotificaciones",
                column: "TipoNotificacionesId");

            migrationBuilder.CreateIndex(
                name: "IX_ModulosNotificaciones_TiposRequerimientosId",
                table: "ModulosNotificaciones",
                column: "TiposRequerimientosId");

            migrationBuilder.CreateIndex(
                name: "IX_RolesvsMaestros_ModulosMaestrosId",
                table: "RolesvsMaestros",
                column: "ModulosMaestrosId");

            migrationBuilder.CreateIndex(
                name: "IX_RolesvsMaestros_RolesId",
                table: "RolesvsMaestros",
                column: "RolesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlockChains");

            migrationBuilder.DropTable(
                name: "GenericosvsSubmodulos");

            migrationBuilder.DropTable(
                name: "ModulosNotificaciones");

            migrationBuilder.DropTable(
                name: "RolesvsMaestros");

            migrationBuilder.DropTable(
                name: "Auditorias");

            migrationBuilder.DropTable(
                name: "MaestrosvsSubmodulos");

            migrationBuilder.DropTable(
                name: "PermisosGenericos");

            migrationBuilder.DropTable(
                name: "EstadoNotificaciones");

            migrationBuilder.DropTable(
                name: "Formatos");

            migrationBuilder.DropTable(
                name: "HilosRepuestas");

            migrationBuilder.DropTable(
                name: "Radicados");

            migrationBuilder.DropTable(
                name: "TipoNotificaciones");

            migrationBuilder.DropTable(
                name: "TipoRequerimientos");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "ModulosMaestros");

            migrationBuilder.DropTable(
                name: "Submodulos");
        }
    }
}
