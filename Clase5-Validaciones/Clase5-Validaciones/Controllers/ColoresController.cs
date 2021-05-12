using Logica;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Clase5_Validaciones.Controllers
{
    public class ColoresController : Controller
    {
        public static List<Color> Colores = new List<Color>();

        private readonly ILogger<ColoresController> _logger;
        public ColoresController(ILogger<ColoresController> logger)
        {
            _logger = logger;
            if (Colores.Count == 0)
            {
                Colores = ColoresManager.ObtenerColores().OrderBy(o => o.Name).ToList();
            }
        }

        public IActionResult Index()
        {
            ViewData["Colores"] = Colores;
            return View();
        }

        [HttpPost]
        public IActionResult Index(Color Color)
        {
            string key = "colores";
            string sessionValue = JsonConvert.SerializeObject(Color);
            HttpContext.Session.SetString(key, sessionValue);
            return Redirect("/Home/Index");
        }
    }
}
