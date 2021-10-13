using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioApi.Models
{
    public class Almacen
    {
        [Key] //llave primaria para poder buscar la cancion con el nombre
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} es requerido")]
        public string Producto { get; set; } //nombre cancion abajo de llave primaria
        //[Required(AllowEmptyStrings = false, ErrorMessage = "{0} es requerido")] //data anotation todos los campos son requeridos, no se permiten campos vacios o muestra mensaje de error
        public int Precio { get; set; } //Autor
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} es requerido")] //requerido llenar
        [StringLength(200, MinimumLength = 5, ErrorMessage = "La longitud de {0} debe estar entre {2} y {1}")] //minimo 10 caracteres maximo 200
        public string Descripcion { get; set; } //letra
        [Display(Name = "Cantidad")]
        public int Cantidad { get; set; }
    }
}
