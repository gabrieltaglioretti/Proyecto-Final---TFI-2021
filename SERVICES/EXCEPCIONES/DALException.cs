using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICIOS.EXCEPCIONES
{
    public class DALException : Exception
    {
        public DALException(Exception ex) : base("DAL Exception", ex)
        {

        }
    }
}
