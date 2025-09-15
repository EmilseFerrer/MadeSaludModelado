using MadeSalud.BD.DATOS;
using MadeSalud.BD.DATOS.ENTITY;
using MadeSalud.Repositorio.IRepositorios;
using MadeSalud.Repositorio.Repositorios;
using MadeSalud.Shared.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MadeSalud.Repositorio.Repositorios
{
    public class MedicoRepositorio : Repositorio<Medico>, IMedicoRepositorio
    {
        private readonly AppDBContext context;
        public MedicoRepositorio(AppDBContext context) : base(context)
        {
            this.context = context;
        }


        public async Task<Medico?> SelectByMatricula(string cod)
        {
            return await context.Set<Medico>().FirstOrDefaultAsync(x => x.MatriculaProfesional == cod);
        }

        public async Task<List<MedicoListadoDTO>> SelectListaMedico(int personaId)
        {
            var medicos = await context.Medicos
                .Include(p => p.Personas)
                .Where(p => p.PersonaId == personaId)
                .Select(p => new MedicoListadoDTO
                {
                    Id = p.Id,
                    DatosMedico = $"{p.Personas!.Nombre} {p.Personas.Apellido} - DNI: {p.Personas.DNI} " +
                    $"- N° de Matrícula:  {p.MatriculaProfesional} "
                })
                .ToListAsync();

            return medicos;
        }

        
    }
}