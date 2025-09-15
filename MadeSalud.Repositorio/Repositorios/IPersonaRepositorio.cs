using MadeSalud.BD.DATOS.ENTITY;
using MadeSalud.Repositorio.Repositorios;
using MadeSalud.Shared.DTO;

namespace MadeSalud.Repositorio.IRepositorios
{
    public interface IPersonaRepositorio : IRepositorio<Persona>
    {
        
        Task<Persona?> SelectByDni(string DNI);
        
        Task<List<PersonaListadoDTO>> SelectListaPersona();

    }
}