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

        [HttpGet] //api/Persona
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

        [HttpGet("Id/{id:int}")] //api/Persona/Id/5
        public async Task<ActionResult<Persona>> GetById(int id)
        {
            var entidad = await repositorio.SelectById(id);
            if (entidad is null)
            {
                return NotFound($"No existe el registro con el id: {id}.");
            }

            return Ok(entidad);
        }

        [HttpGet("Dni/{dni}")] //api/Persona/Dni/12345678
        public async Task<ActionResult<Persona>> GetByDni(string dni)
        {
            var entidad = await repositorio.SelectByDni(dni);
            if (entidad is null)
            {
                return NotFound($"No existe el registro con el DNI: {dni}.");
            }

            return Ok(entidad);
        }

        [HttpGet("ListaPersona")] //api/Persona/ListaPersona
        public async Task<ActionResult<List<PersonaListadoDTO>>> GetListaPersona()
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

        [HttpPost] //api/Persona
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

        [HttpPut("{id:int}")] //api/Persona/5
        public async Task<ActionResult> Put(int id, PersonaCrearDTO dto)
        {
            // Convertir el DTO a entidad
            var entidad = new Persona
            {
                Id = id,
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                DNI = dto.DNI,
                Telefono = dto.Telefono,
                Direccion = dto.Direccion,
                Sexo = dto.Sexo,
                FechaNacimiento = dto.FechaNacimiento,
                Rol = dto.Rol
                // Agrega otros campos si existen en la entidad
            };

            var resultado = await repositorio.Update(id, entidad);
            if (!resultado)
            {
                return BadRequest("Datos no válidos");
            }
            return Ok($"El registro con el id: {id} fue actualizado correctamente.");
        }

        [HttpDelete("{id:int}")] //api/Persona/5
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
