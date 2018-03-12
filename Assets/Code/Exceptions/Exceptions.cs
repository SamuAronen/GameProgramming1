using System.IO;
using GameProgramming1.Systems;

namespace GameProgramming1.Exceptions
{
    public class LocalizationNotFoundException : FileNotFoundException
    {
        public LangCode Language { get; private set; }

        public LocalizationNotFoundException(LangCode langCode)
        {
            Language = langCode;

        }

        public override string Message
        {
            get { return "Localization file not found for language" + Language; }
        }
    }
}
