using System;
using SERVICIOS.EXCEPCIONES;

namespace SERVICIOS.SERVICIOS.Exceptions
{
    public static class Service
    {
        public static void Handle(Exception ex)
        {
            ExceptionManager.Current.Handle(ex);
        }

        //public static string Translate(string codigoIdioma, string word)
        //{
        //    return LanguageManager.Current.Translate(codigoIdioma, word);
        //}
    }
}
