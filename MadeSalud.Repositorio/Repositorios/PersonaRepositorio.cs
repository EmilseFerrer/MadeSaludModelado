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
    public class PersonaRepositorio : Repositorio<Persona>, IPersonaRepositorio
    {
        private readonly AppDBContext context;

        public PersonaRepositorio(AppDBContext context) : base(context)
        {
            this.context = context;
        }

       

        public async Task<Persona?> SelectByDni(string dni)
        {
            return await context.Set<Persona>().FirstOrDefaultAsync(x => x.DNI == dni);
        }


        public async Task<List<PersonaListadoDTO>> SelectListaPersona()
        {
            var lista = await context.Personas
                            .Select(p => new PersonaListadoDTO
                            {
                                Id = p.Id,
                                DatosPersona = $"{p.Nombre} {p.Apellido} -  DNI: {p.DNI} - {p.Sexo} - " +
                                $" Rol: {p.Rol}",
                            })
                            .ToListAsync();

            return lista;
        }
        public async Task<List<PersonaListadoDTO>> SelectListaMedicos()
        {
            return await context.Medicos
                        .Include(m => m.Personas)
                        .Select(m => new PersonaListadoDTO
                        {
                            Id = m.Personas.Id,
                            DatosPersona = $"{m.Personas.Nombre} {m.Personas.Apellido} -  DNI: {m.Personas.DNI} - {m.Personas.Sexo} - " +
                               $" Rol: {m.Personas.Rol} - ",
                            MatriculaProfesional = m.MatriculaProfesional
                        })
                        .ToListAsync();
        }

        public async Task<List<PersonaListadoDTO>> SelectListaPacientes()
        {
            return await context.Pacientes
                        .Include(p => p.Personas)
                        .Include(p => p.HistoriaClinicas) 
                        .Select(p => new PersonaListadoDTO
                        {
                            Id = p.Personas.Id,
                            DatosPersona = $"{p.Personas.Nombre} {p.Personas.Apellido} -  DNI: {p.Personas.DNI} - {p.Personas.Sexo} - " +
                               $" Rol: {p.Personas.Rol}",
                            NHC = p.HistoriaClinicas
                                                        .OrderBy(h => h.Id)
                                                        .Select(h => h.NHC) 
                                                        .FirstOrDefault()
                        })
                        .ToListAsync();
        }

        public async Task<List<PersonaListadoDTO>> SelectListaSecretarias()
        {
            return await context.Secretarias
                       .Include(s => s.Personas)
                       .Select(s => new PersonaListadoDTO
                       {
                           Id = s.Personas.Id,
                           DatosPersona = $"{s.Personas.Nombre} {s.Personas.Apellido} -  DNI: {s.Personas.DNI} - {s.Personas.Sexo} - " +
                               $" Rol: {s.Personas.Rol}",
                           NLegajo = s.NLegajo
                       })
                       .ToListAsync();
        }

    }
}
