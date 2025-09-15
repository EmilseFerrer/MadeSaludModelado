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
                                        
                                        DatosPersona = $"{p.Nombre} {p.Apellido} -DNI: {p.DNI} " +
                                        $" - {p.Sexo} - Rol: {p.Rol} "
                                        
                                    })
                                    .ToListAsync();
            return lista;
        }

        
    }
}
