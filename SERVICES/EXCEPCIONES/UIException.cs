using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICIOS.EXCEPCIONES
{
    public class UIException : Exception
    {
        public UIException(String message) : base(message)
        {

        }

    }
}
