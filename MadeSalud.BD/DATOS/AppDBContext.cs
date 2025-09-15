using MadeSalud.BD.DATOS.ENTITY;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadeSalud.BD.DATOS
{
    public class AppDBContext : DbContext
    {

        public required DbSet<Persona> Personas { get; set; }
        
        public required DbSet<Paciente> Pacientes { get; set; }
        
        public required DbSet<Medico> Medicos { get; set; }
        
        public required DbSet<Secretaria> Secretarias { get; set; }
        
        public required DbSet<Turno> Turnos { get; set; }

        public required DbSet<HistoriaClinica> HistoriasClinicas { get; set; }

        public required DbSet<ConsultaMedica> ConsultasMedicas { get; set; }    

        public required DbSet<Medicamento> Medicamentos { get; set; }

        public required DbSet<PedidoLaboratorio> PedidosLaboratorio { get; set; }

        public required DbSet<DetallePedidoLaboratorio> DetallesPedidosLaboratorio { get; set; }

        public required DbSet<Receta> Recetas { get; set; } 


        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);//configurar entidades

            var cascadeFKs = modelBuilder.Model
               .G­etEntityTypes()
               .SelectMany(t => t.GetForeignKeys())
               .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Casca­de);
            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Restr­ict;
            }
        }


    }
}
