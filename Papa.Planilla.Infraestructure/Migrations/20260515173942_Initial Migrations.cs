using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Papa.Planilla.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "planilla");

            migrationBuilder.CreateTable(
                name: "cargos",
                schema: "planilla",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    descripcion = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Estado = table.Column<bool>(type: "boolean", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioCreacion = table.Column<int>(type: "integer", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UsuarioActualizacion = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cargos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "trabajadores",
                schema: "planilla",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    tipo_documento = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: false),
                    numero_documento = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    apellido_paterno = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    apellido_materno = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    nombres = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    correo = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    celular_codigo_pais = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    celular_numero = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Estado = table.Column<bool>(type: "boolean", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioCreacion = table.Column<int>(type: "integer", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UsuarioActualizacion = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trabajadores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "unidades_organicas",
                schema: "planilla",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    descripcion = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: false),
                    codigo_presupuestal = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    codigo_presupuestal_descripcion = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Estado = table.Column<bool>(type: "boolean", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioCreacion = table.Column<int>(type: "integer", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UsuarioActualizacion = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unidades_organicas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "contratos",
                schema: "planilla",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TrabajadorId = table.Column<Guid>(type: "uuid", nullable: false),
                    UnidadOrganicaId = table.Column<Guid>(type: "uuid", nullable: false),
                    CargoId = table.Column<Guid>(type: "uuid", nullable: false),
                    fecha_inicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    fecha_fin = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    sueldo_moneda = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    sueldo_monto = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    estado_contrato = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Estado = table.Column<bool>(type: "boolean", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioCreacion = table.Column<int>(type: "integer", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UsuarioActualizacion = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contratos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_contratos_cargos_CargoId",
                        column: x => x.CargoId,
                        principalSchema: "planilla",
                        principalTable: "cargos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_contratos_trabajadores_TrabajadorId",
                        column: x => x.TrabajadorId,
                        principalSchema: "planilla",
                        principalTable: "trabajadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_contratos_unidades_organicas_UnidadOrganicaId",
                        column: x => x.UnidadOrganicaId,
                        principalSchema: "planilla",
                        principalTable: "unidades_organicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "planillas",
                schema: "planilla",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    anio_planilla = table.Column<int>(type: "integer", nullable: false),
                    mes_planilla = table.Column<int>(type: "integer", nullable: false),
                    TrabajadorId = table.Column<Guid>(type: "uuid", nullable: false),
                    ContratoId = table.Column<Guid>(type: "uuid", nullable: false),
                    sueldo_basico_moneda = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    sueldo_basico_monto = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    total_ingresos_moneda = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    total_ingresos_monto = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    total_descuento_moneda = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    total_descuento_monto = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    estado_planilla = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Estado = table.Column<bool>(type: "boolean", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioCreacion = table.Column<int>(type: "integer", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UsuarioActualizacion = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_planillas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_planillas_contratos_ContratoId",
                        column: x => x.ContratoId,
                        principalSchema: "planilla",
                        principalTable: "contratos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_planillas_trabajadores_TrabajadorId",
                        column: x => x.TrabajadorId,
                        principalSchema: "planilla",
                        principalTable: "trabajadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_contratos_CargoId",
                schema: "planilla",
                table: "contratos",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_contratos_estado_contrato",
                schema: "planilla",
                table: "contratos",
                column: "estado_contrato");

            migrationBuilder.CreateIndex(
                name: "IX_contratos_fecha_fin",
                schema: "planilla",
                table: "contratos",
                column: "fecha_fin");

            migrationBuilder.CreateIndex(
                name: "IX_contratos_fecha_inicio",
                schema: "planilla",
                table: "contratos",
                column: "fecha_inicio");

            migrationBuilder.CreateIndex(
                name: "IX_contratos_TrabajadorId",
                schema: "planilla",
                table: "contratos",
                column: "TrabajadorId");

            migrationBuilder.CreateIndex(
                name: "IX_contratos_UnidadOrganicaId",
                schema: "planilla",
                table: "contratos",
                column: "UnidadOrganicaId");

            migrationBuilder.CreateIndex(
                name: "IX_planillas_anio_planilla",
                schema: "planilla",
                table: "planillas",
                column: "anio_planilla");

            migrationBuilder.CreateIndex(
                name: "IX_planillas_ContratoId",
                schema: "planilla",
                table: "planillas",
                column: "ContratoId");

            migrationBuilder.CreateIndex(
                name: "IX_planillas_estado_planilla",
                schema: "planilla",
                table: "planillas",
                column: "estado_planilla");

            migrationBuilder.CreateIndex(
                name: "IX_planillas_mes_planilla",
                schema: "planilla",
                table: "planillas",
                column: "mes_planilla");

            migrationBuilder.CreateIndex(
                name: "IX_planillas_TrabajadorId",
                schema: "planilla",
                table: "planillas",
                column: "TrabajadorId");

            migrationBuilder.CreateIndex(
                name: "IX_trabajadores_celular_codigo_pais_celular_numero",
                schema: "planilla",
                table: "trabajadores",
                columns: new[] { "celular_codigo_pais", "celular_numero" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_trabajadores_tipo_documento_numero_documento",
                schema: "planilla",
                table: "trabajadores",
                columns: new[] { "tipo_documento", "numero_documento" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_unidades_organicas_codigo_presupuestal_codigo_presupuestal_~",
                schema: "planilla",
                table: "unidades_organicas",
                columns: new[] { "codigo_presupuestal", "codigo_presupuestal_descripcion" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "planillas",
                schema: "planilla");

            migrationBuilder.DropTable(
                name: "contratos",
                schema: "planilla");

            migrationBuilder.DropTable(
                name: "cargos",
                schema: "planilla");

            migrationBuilder.DropTable(
                name: "trabajadores",
                schema: "planilla");

            migrationBuilder.DropTable(
                name: "unidades_organicas",
                schema: "planilla");
        }
    }
}
