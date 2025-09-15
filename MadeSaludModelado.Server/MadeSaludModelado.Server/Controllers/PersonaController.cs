using MadeSalud.BD.DATOS;
using MadeSalud.BD.DATOS.ENTITY;
using MadeSalud.Repositorio.IRepositorios;
using MadeSalud.Repositorio.Repositorios;
using MadeSalud.Shared.DTO;
using MadeSalud.Shared.ENUM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MadeSaludModelado.Server.Controllers
{
    [ApiController]
    [Route("api/Persona")]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaRepositorio repositorio;
        public PersonaController(IPersonaRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Persona>>> GetList()
        {
            var lista = await repositorio.Select();
            if (lista == null)
            {
                return NotFound("No se encontro la lista, VERIFICAR.");
            }
            if (lista.Count == 0)
            {
                return Ok("No existen items en la lista en este momento");
            }

            return Ok(lista);
        }

        [HttpGet("Id/{id:int}")]
        public async Task<ActionResult<Persona>> GetById(int id)
        {
            var entidad = await repositorio.SelectById(id);
            if (entidad is null)
            {
                return NotFound($"No existe el registro con el id: {id}.");
            }

            return Ok(entidad);
        }

        [HttpGet("Dni/{dni}")]
        public async Task<ActionResult<Persona>> GetByDni(string dni)
        {
            var entidad = await repositorio.SelectByDni(dni);
            if (entidad is null)
            {
                return NotFound($"No existe el registro con el DNI: {dni}.");
            }

            return Ok(entidad);
        }

        [HttpGet("ListaPersona")]
        public async Task<ActionResult<List<Persona>>> GetListaPersona()
        {
            var lista = await repositorio.SelectListaPersona();
            if (lista == null)
            {
                return NotFound("No se encontro la lista, VERIFICAR.");
            }
            if (lista.Count == 0)
            {
                return Ok("No existen items en la lista en este momento");
            }
            return Ok(lista);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(PersonaCrearDTO DTO)
        {

            try
            {
                Persona entidad = new Persona
                {
                    Nombre = DTO.Nombre,
                    Apellido = DTO.Apellido,
                    DNI = DTO.DNI,
                    Telefono = DTO.Telefono,
                    Direccion = DTO.Direccion,
                    Sexo = DTO.Sexo,
                    FechaNacimiento = DTO.FechaNacimiento,
                    Rol = DTO.Rol,
                    EstadoRegistro = EnumEstadoRegistro.Activo  


                };
                var id = await repositorio.Insert(entidad);
                return Ok(entidad.Id);
            }
            catch (Exception e)
            {
                return BadRequest($"Error al crear el nuevo registro: {e.Message}");
            }

        }

       

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Persona DTO)
        {
            var resultado = await repositorio.Update(id, DTO);
            if (!resultado)
            {
                return BadRequest("Datos no validos");
            }
            return Ok($"El registro con el id: {id} fue actualizado correctamente.");
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var resultado = await repositorio.Delete(id);
            if (!resultado)
            {
                return BadRequest("Datos no validos");
            }
            return Ok($"El registro con el id: {id} fue eliminado correctamente.");
        }
    }
}
