using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;

namespace Logica
{
    public class ColoresManager
    {
        public static List<Color> ObtenerColores()
        {
            return typeof(Color).GetProperties(BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.Public)
                       .Select(c => (Color)c.GetValue(null, null))
                       .ToList();
        }
    }
}
