using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadeSalud.BD.DATOS.ENTITY
{
    public class ConsultaMedica : EntityBase
    {
        public int HistoriaClinicaId { get; set; }
        public HistoriaClinica? HistoriaClinica { get; set; }

        public int MedicoId { get; set; }
        public Medico? Medico { get; set; }

        public int SecretariaId { get; set; }
        public Secretaria? Secretaria { get; set; }

        public int RecetaId { get; set; }
        public Receta? Receta { get; set; }
        
        [Required]
        public DateTime FechaConsulta { get; set; }= DateTime.Now;

        [Required(ErrorMessage = "El diagnóstico es obligatorio")]
        [MaxLength(100, ErrorMessage = "El diagnóstico no puede exceder los {1} caracteres.")]
        public string Diagnostico { get; set; } = string.Empty;

        [Required(ErrorMessage = "Este Campo es obligatorio")]
        [MaxLength(20, ErrorMessage = "No puede superar los {1} caracteres")]
        public string FrecuenciaCardiaca { get; set; } = string.Empty;

        [Required(ErrorMessage = "Este Campo es obligatorio")]
        [MaxLength(20, ErrorMessage = "No puede superar los {1} caracteres")]
        public string PresionArterial { get; set; }= string.Empty;

        [Required(ErrorMessage = "Este Campo es obligatorio")]
        [MaxLength(6, ErrorMessage = "No puede superar los {1} caracteres")]
        public decimal PesoCorporal { get; set; } = 0; 

        public List<Medicamento> Medicamentos { get; set; } = new List<Medicamento>();

    }
}
