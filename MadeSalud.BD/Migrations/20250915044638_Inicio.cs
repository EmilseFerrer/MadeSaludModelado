using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MadeSalud.BD.Migrations
{
    /// <inheritdoc />
    public partial class Inicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DNI = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rol = table.Column<int>(type: "int", nullable: false),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatriculaProfesional = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PersonaId = table.Column<int>(type: "int", nullable: false),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicos_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ObraSocial = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    MotivoConsulta = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PersonaId = table.Column<int>(type: "int", nullable: false),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pacientes_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Secretarias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NLegajo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonaId = table.Column<int>(type: "int", nullable: false),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Secretarias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Secretarias_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HistoriasClinicas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NHC = table.Column<int>(type: "int", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoriasClinicas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoriasClinicas_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Turnos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechayHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    MedicoId = table.Column<int>(type: "int", nullable: false),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turnos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Turnos_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Turnos_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PedidosLaboratorio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SecretariaId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidosLaboratorio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidosLaboratorio_Secretarias_SecretariaId",
                        column: x => x.SecretariaId,
                        principalTable: "Secretarias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConsultasMedicas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HistoriaClinicaId = table.Column<int>(type: "int", nullable: false),
                    MedicoId = table.Column<int>(type: "int", nullable: false),
                    SecretariaId = table.Column<int>(type: "int", nullable: false),
                    RecetaId = table.Column<int>(type: "int", nullable: false),
                    FechaConsulta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Diagnostico = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FrecuenciaCardiaca = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PresionArterial = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PesoCorporal = table.Column<decimal>(type: "decimal(18,2)", maxLength: 6, nullable: false),
                    TurnoId = table.Column<int>(type: "int", nullable: true),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultasMedicas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsultasMedicas_HistoriasClinicas_HistoriaClinicaId",
                        column: x => x.HistoriaClinicaId,
                        principalTable: "HistoriasClinicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConsultasMedicas_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConsultasMedicas_Secretarias_SecretariaId",
                        column: x => x.SecretariaId,
                        principalTable: "Secretarias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConsultasMedicas_Turnos_TurnoId",
                        column: x => x.TurnoId,
                        principalTable: "Turnos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Medicamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<int>(type: "int", maxLength: 6, nullable: false),
                    NombreFormula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConsultaMedicaId = table.Column<int>(type: "int", nullable: true),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicamentos_ConsultasMedicas_ConsultaMedicaId",
                        column: x => x.ConsultaMedicaId,
                        principalTable: "ConsultasMedicas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DetallesPedidosLaboratorio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    MedicamentoId = table.Column<int>(type: "int", nullable: false),
                    PedidoLaboratorioId = table.Column<int>(type: "int", nullable: false),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesPedidosLaboratorio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetallesPedidosLaboratorio_Medicamentos_MedicamentoId",
                        column: x => x.MedicamentoId,
                        principalTable: "Medicamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetallesPedidosLaboratorio_PedidosLaboratorio_PedidoLaboratorioId",
                        column: x => x.PedidoLaboratorioId,
                        principalTable: "PedidosLaboratorio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Recetas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dosis = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Frecuencia = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ConsultaId = table.Column<int>(type: "int", nullable: false),
                    MedicamentoId = table.Column<int>(type: "int", nullable: false),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recetas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recetas_Medicamentos_MedicamentoId",
                        column: x => x.MedicamentoId,
                        principalTable: "Medicamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsultasMedicas_HistoriaClinicaId",
                table: "ConsultasMedicas",
                column: "HistoriaClinicaId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultasMedicas_MedicoId",
                table: "ConsultasMedicas",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultasMedicas_RecetaId",
                table: "ConsultasMedicas",
                column: "RecetaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConsultasMedicas_SecretariaId",
                table: "ConsultasMedicas",
                column: "SecretariaId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultasMedicas_TurnoId",
                table: "ConsultasMedicas",
                column: "TurnoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesPedidosLaboratorio_MedicamentoId",
                table: "DetallesPedidosLaboratorio",
                column: "MedicamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesPedidosLaboratorio_PedidoLaboratorioId",
                table: "DetallesPedidosLaboratorio",
                column: "PedidoLaboratorioId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoriasClinicas_PacienteId",
                table: "HistoriasClinicas",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "NHC_UQ",
                table: "HistoriasClinicas",
                column: "NHC",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medicamentos_ConsultaMedicaId",
                table: "Medicamentos",
                column: "ConsultaMedicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_PersonaId",
                table: "Medicos",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "MP_UQ",
                table: "Medicos",
                column: "MatriculaProfesional",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_PersonaId",
                table: "Pacientes",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidosLaboratorio_SecretariaId",
                table: "PedidosLaboratorio",
                column: "SecretariaId");

            migrationBuilder.CreateIndex(
                name: "DNI_UQ",
                table: "Personas",
                column: "DNI",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recetas_MedicamentoId",
                table: "Recetas",
                column: "MedicamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Secretarias_PersonaId",
                table: "Secretarias",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_MedicoId",
                table: "Turnos",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_PacienteId",
                table: "Turnos",
                column: "PacienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsultasMedicas_Recetas_RecetaId",
                table: "ConsultasMedicas",
                column: "RecetaId",
                principalTable: "Recetas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsultasMedicas_HistoriasClinicas_HistoriaClinicaId",
                table: "ConsultasMedicas");

            migrationBuilder.DropForeignKey(
                name: "FK_ConsultasMedicas_Medicos_MedicoId",
                table: "ConsultasMedicas");

            migrationBuilder.DropForeignKey(
                name: "FK_Turnos_Medicos_MedicoId",
                table: "Turnos");

            migrationBuilder.DropForeignKey(
                name: "FK_ConsultasMedicas_Recetas_RecetaId",
                table: "ConsultasMedicas");

            migrationBuilder.DropTable(
                name: "DetallesPedidosLaboratorio");

            migrationBuilder.DropTable(
                name: "PedidosLaboratorio");

            migrationBuilder.DropTable(
                name: "HistoriasClinicas");

            migrationBuilder.DropTable(
                name: "Medicos");

            migrationBuilder.DropTable(
                name: "Recetas");

            migrationBuilder.DropTable(
                name: "Medicamentos");

            migrationBuilder.DropTable(
                name: "ConsultasMedicas");

            migrationBuilder.DropTable(
                name: "Secretarias");

            migrationBuilder.DropTable(
                name: "Turnos");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Personas");
        }
    }
}
