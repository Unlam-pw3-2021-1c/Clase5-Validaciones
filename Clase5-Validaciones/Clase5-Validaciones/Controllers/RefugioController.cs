using Clase5_Validaciones.Models;
using Logica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
                Colores = ColoresManager.ObtenerColores().OrderBy(o=> o.Name).ToList();
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
            ViewData["Especies"] = Especies;
            ViewData["Colores"] = Colores;

            if (!ModelState.IsValid)
            {
                return View(mascota);
            }
            foreach (var f in Request.Form.Files)
            {
                string path = Path.GetTempFileName();
                using (var stream = System.IO.File.Create(path))
                {
                    f.CopyTo(stream);
                }
                mascota.Fotos.Add(path);
            }

            if (Mascotas.Count == 0)
            {
                mascota.Id = 1;
            }
            else
            {
                mascota.Id = Mascotas.Max(o => o.Id) + 1;
            }

            Mascotas.Add(mascota);
            return View();
        }

   
    }
}
