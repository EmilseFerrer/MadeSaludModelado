using MadeSalud.BD.DATOS.ENTITY;
using MadeSalud.Repositorio.Repositorios;
using MadeSalud.Shared.DTO;

namespace MadeSalud.Repositorio.IRepositorios
{
    public interface ISecretariaRepositorio : IRepositorio<Secretaria>
    {
        Task<Secretaria?> SelectByNLegajo(string cod);
        
        Task<List<SecretariaListadoDTO>> SelectListaSecretaria(int personaId);

    }
}