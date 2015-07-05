using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProveedorServicio.Utils
{
    public static class ExceptionExtensiones
    {
        public static string ObtenerInnerException(this Exception aException)
        {
            while (true)
            {
                if (aException.InnerException == null) return aException.Message;
                aException = aException.InnerException;
            }
        }
    }
}