using System;
using System.IO;

namespace SERVICIOS.TRADUCCION
{
    internal sealed class LanguageManager
    {

        #region Singleton
        private readonly static LanguageManager _instance = new LanguageManager();

        public static LanguageManager Current
        {
            get
            {
                return _instance;
            }
        }

        private LanguageManager()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public string Translate(string word, string language)
        {
            try
            {
                string line;
                string[] words;

                if (language == "en-US")
                {
                    string filePath = ApplicationSettings.Current.file_enUS;

                    StreamReader file = new StreamReader(filePath);

                    while ((line = file.ReadLine()) != null)
                    {
                        words = line.Split(':');

                        if (words[0] == word)
                        {
                            file.Close();
                            return words[1];
                        }

                    }

                    file.Close();
                }

                if (language == "es-ES")
                {
                    string filePath = ApplicationSettings.Current.file_esES;

                    StreamReader file = new StreamReader(filePath);

                    while ((line = file.ReadLine()) != null)
                    {
                        words = line.Split(':');

                        if (words[0] == word)
                        {
                            file.Close();
                            return words[1];
                        }

                    }

                    file.Close();
                }

                if (language == "pt-BR")
                {
                    string filePath = ApplicationSettings.Current.file_ptBR;

                    StreamReader file = new StreamReader(filePath);

                    while ((line = file.ReadLine()) != null)
                    {
                        words = line.Split(':');

                        if (words[0] == word)
                        {
                            file.Close();
                            return words[1];
                        }

                    }

                    file.Close();
                }

                return word;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }


}
