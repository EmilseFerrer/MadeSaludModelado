using MadeSalud.BD.DATOS.ENTITY;
using MadeSalud.Repositorio.Repositorios;
using MadeSalud.Shared.DTO;
using MadeSalud.Shared.ENUM;

namespace MadeSalud.Repositorio.IRepositorios
{
    public interface IPacienteRepositorio : IRepositorio<Paciente>
    {
        
        Task<List<PacienteListadoDTO>> SelectListaPaciente(int PersonaId);
     
    }
}