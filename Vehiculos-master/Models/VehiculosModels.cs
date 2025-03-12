using System.ComponentModel.DataAnnotations;

namespace Vehiculos.Models
{
    public class VehiculosModels

    {
        [Key]
        public int VehiculoId { get; set; }  // Renombrado a VehiculoId para reflejar la tabla de base de datos


        [Required(ErrorMessage = "El campo es requerido")]
        public string Marca { get; set; }


        [Required(ErrorMessage = "El campo es requerido")]
        public string Modelo { get; set; }


        [Required(ErrorMessage = "El campo es requerido")]
        public int Año { get; set; }


        public bool Disponible { get; set; }


        // Relación con Alquileres
        public ICollection<AlquileresModels> Alquileres { get; set; }
    }
}
