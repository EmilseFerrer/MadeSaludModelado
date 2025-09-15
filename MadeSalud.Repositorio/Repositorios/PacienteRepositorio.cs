using MadeSalud.BD.DATOS;
using MadeSalud.BD.DATOS.ENTITY;
using MadeSalud.Repositorio.IRepositorios;
using MadeSalud.Repositorio.Repositorios;
using MadeSalud.Shared.DTO;
using MadeSalud.Shared.ENUM;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MadeSalud.Repositorio.Repositorios
{
    public class PacienteRepositorio : Repositorio<Paciente>, IPacienteRepositorio
    {
        private readonly AppDBContext context;

        public PacienteRepositorio(AppDBContext context) : base(context)
        {
            this.context = context;
        }






        public async Task<List<PacienteListadoDTO>> SelectListaPaciente(int personaId)
        {
            var pacientes = await context.Pacientes

                .Include(p => p.Personas)
                .Where(p => p.PersonaId == personaId)
                .Select(p => new PacienteListadoDTO
                {
                    Id = p.Id,


                    DatosPaciente = $"{p.Personas!.Nombre} {p.Personas.Apellido} - DNI: {p.Personas.DNI} " +
                    $"- Obra Social: {p.ObraSocial} - Motivo Consulta: {p.MotivoConsulta}"
                })
                .ToListAsync();

            return pacientes;
        }
    }
}

