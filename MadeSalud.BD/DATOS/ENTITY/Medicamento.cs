using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadeSalud.BD.DATOS.ENTITY
{
    public class Medicamento : EntityBase
    {
        [Required(ErrorMessage="El Código del Medicamento es Obligatorio")]
        [MaxLength(6,ErrorMessage = "El máximo de caracteres es {1}")]
        public required int Codigo { get; set; }

        public required string NombreFormula { get; set; }

    }
}
