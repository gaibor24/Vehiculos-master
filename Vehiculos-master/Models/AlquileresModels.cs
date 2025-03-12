using System.ComponentModel.DataAnnotations;

namespace Vehiculos.Models
{
    public class AlquileresModels
    {
        [Key]
        public int AlquilerId { get; set; }  // Renombrado a AlquilerId


        [Required(ErrorMessage = "El campo es requerido")]
        [DataType(DataType.Date)]
        public DateTime FechaInicio { get; set; }


        [Required(ErrorMessage = "El campo es requerido")]
        [DataType(DataType.Date)]
        public DateTime FechaFin { get; set; }


        // Claves foráneas
        public int VehiculoId { get; set; }
        public VehiculosModels Vehiculo { get; set; }  // Relación con Vehiculos


        public int ClienteId { get; set; }
        public ClientesModels Cliente { get; set; }  // Relación con Clientes
    }
}
