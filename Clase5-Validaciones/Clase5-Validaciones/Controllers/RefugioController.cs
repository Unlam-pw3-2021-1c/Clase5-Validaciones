using Clase5_Validaciones.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Clase5_Validaciones.Controllers
{
    public class RefugioController : Controller
    {
        public static List<Mascota> Mascotas = new List<Mascota>();
        public static List<Especie> Especies = new List<Especie>();
        public static List<Color> Colores = new List<Color>();
        public RefugioController()
        {
            if (Especies.Count == 0)
            {
                Especies = new List<Especie>() {
                                new Especie() { Id = 1, Nombre = "Perro" }, 
                                new Especie() { Id = 2, Nombre = "Gato" },
                                new Especie() { Id = 3, Nombre = "Tortuga" },
                                new Especie() { Id = 4, Nombre = "Pez" },
                                new Especie() { Id = 5, Nombre = "Hamster" }
                }.OrderBy(o=> o.Nombre)
                .ToList();
            }

            if (Colores.Count == 0)
            {
                Colores = ObtenerColores().OrderBy(o=> o.Name).ToList();
            }
        }
        public IActionResult AgregarMascotaEncontrada()
        {
            ViewData["Especies"] = Especies;
            ViewData["Colores"] = Colores;
            return View();
        }

        [HttpPost]
        public IActionResult AgregarMascotaEncontrada(Mascota mascota)
        {
            Mascotas.Add(mascota);
            return View();
        }

        private static List<Color> ObtenerColores()
        {
            return typeof(Color).GetProperties(BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.Public)
                       .Select(c => (Color)c.GetValue(null, null))
                       .ToList();
        }
    }
}
