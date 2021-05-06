using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clase5_Validaciones.Models
{
    public class Mascota
    {
        public int Id { get; set; }
        //[Required(ErrorMessage ="Campo requerido")]
        public Especie Especie { get; set; }
        [Required(ErrorMessage ="Campo requerido")]
        public string Estado { get; set; }
        //[Range(0, 5000, ErrorMessage ="El peso debe estar entre 0 y 5000")]
        public int Peso { get; set; }
        public string Color { get; set; }
        [StringLength(200, ErrorMessage ="No se puede ingresar mas de 200 caracteres")]
        public string Nombre { get; set; }
        public string DatosDeContacto { get; set; }
        public List<string> Fotos { get; set; }
    }
}
