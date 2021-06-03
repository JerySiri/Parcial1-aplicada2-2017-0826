using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Parcial1_aplicada2_2017_0826.Models
{
    public class Productos
    {
        [Key]
        public int ProductoId { get; set; }

        [Required(ErrorMessage = " Este campo de descripción no puede estar vacio.")]
        public String Descripcion { get; set; }

        public float Existencia { get; set; } = 0;

        public float Costos { get; set; } = 0;

        public float ValorInventario { get; set; } = 0;

    }
}
