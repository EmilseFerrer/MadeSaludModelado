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
    public class SecretariaRepositorio : Repositorio<Secretaria>, ISecretariaRepositorio
    {
        private readonly AppDBContext context;

        public SecretariaRepositorio(AppDBContext context) : base(context)
        {
            this.context = context;
        }


        public async Task<Secretaria?> SelectByNLegajo(string cod)
        {
            return await context.Set<Secretaria>().FirstOrDefaultAsync(x => x.NLegajo == cod);
        }


        public async Task<List<SecretariaListadoDTO>> SelectListaSecretaria(int personaId)
        {
            var secretarias = await context.Secretarias
                .Include(p => p.Personas)
                .Where(p => p.PersonaId == personaId)
                .Select(p => new SecretariaListadoDTO
                {
                    Id = p.Id,
                    DatosSecre = $"{p.Personas!.Nombre} {p.Personas.Apellido} - DNI: {p.Personas.DNI} " +
                    $"- N° de Legajo:  {p.NLegajo} "
                })
                .ToListAsync();
            
            return secretarias;
        }

    
    }
}
