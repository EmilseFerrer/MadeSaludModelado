using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadeSalud.BD.DATOS.ENTITY
{
    public class DetallePedidoLaboratorio : EntityBase
    {
        [Required(ErrorMessage = "La cantidad es obligatoria")]
        [MaxLength(4, ErrorMessage = "El máximo es {1} números")]
        public int Cantidad { get; set; }

        public int MedicamentoId { get; set; }
        public Medicamento? Medicamento { get; set; }

        public int PedidoLaboratorioId { get; set; }
        public PedidoLaboratorio? PedidoLaboratorio { get; set; }



    }
       
}
