using System.ComponentModel.DataAnnotations;

namespace Vehiculos.Models
{
    public class ClientesModels
    {
        [Key]
        public int ClienteId { get; set; }  // Renombrado a ClienteId

        [Required(ErrorMessage = "El campo es requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        public string Licencia { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        public string Telefono { get; set; }

        // Relación con Alquileres
        public ICollection<AlquileresModels> Alquileres { get; set; }
    }
}
