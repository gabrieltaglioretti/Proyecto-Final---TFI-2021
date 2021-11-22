
using SERVICIOS.TRADUCCION;

namespace SERVICIOS.TRADUCCION.Facade.Extensions
{
    public static class StringExtension
    {
        public static string Translate(this string word, string language)
        {
            return LanguageManager.Current.Translate(word, language);
        }
    }
}
