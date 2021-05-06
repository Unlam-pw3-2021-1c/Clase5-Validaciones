using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clase5_Validaciones.Models
{
    public class Mascota
    {
        public int Id { get; set; }
        public Especie Especie { get; set; }
        public string Estado { get; set; }
        public float Peso { get; set; }
        public string Color { get; set; }
        public string Nombre { get; set; }
        public string DatosDeContacto { get; set; }
        public List<string> Fotos { get; set; }
    }
}
