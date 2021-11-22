using SERVICIOS.EXCEPCIONES;
using System;

namespace SERVICIOS.EXCEPCIONES
{

    internal sealed class ExceptionManager
    {
        #region Singleton
        private readonly static ExceptionManager _instance = new ExceptionManager();

        public static ExceptionManager Current
        {
            get
            {
                return _instance;
            }
        }

        private ExceptionManager()
        {
            //Implement here the initialization code
        }
        #endregion

        public void Handle(Exception ex)
        {
            if(ex is BLLException)
            {
                Handle(ex as BLLException);
            }
            else if (ex is DALException)
            {
                Handle(ex as DALException);
            }
            else if (ex is UIException)
            {
                Handle(ex as UIException);
            }
            else
            {
                //Ver qué hacemos con excepciones que no son esperadas por mi componente...

                //???? QUIÉN SOS???
                //Registrar... Severity -> NOT FOUND?


                throw ex;
            }
        }

        private void Handle(BLLException ex)
        {
            if(ex.InnerException is DALException)
            {
                //Si viene de DAL reemplazo el mensaje y lanzo...
                throw new Exception("Error accediendo a base de datos", ex);
            }
            else if(ex.IsBusinessException)
            {
                //Es una excepción de reglas de negocio...
                //Registro y relanzo


                throw ex;
            }
            else
            {
                //Es una excepción de BLL no especificada...

                //Registrar la excepción

                throw new Exception("Error de negocio. Consulte con Gimenez -> NNNNN", ex);
            }
        }

        private void Handle(DALException ex)
        {
            //Registrar en archivo/DB/email/wp/event log...logs
            
            //Registrar este envento en una bitácora...

            throw ex;
        }

        private void Handle(UIException ex)
        {
            //Registrar la exception...


        }
    }

}
