using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public static class SessionManager
    {
        public static bool IntentarObtenerValor<T>(ISession session, string clave, out T valor)
        {
            string valorString;
            try
            {
                valorString = session.GetString(clave);
                valor = JsonConvert.DeserializeObject<T>(valorString);
                return true;
            }
            catch (Exception ex)
            {
                valor = default(T);
                return false;
            }
        }

        public static void GuardarValor<T>(ISession session, string clave, T valor)
        {
            string stringValue = JsonConvert.SerializeObject(valor);
            session.SetString(clave, stringValue);
        }

    }
}
