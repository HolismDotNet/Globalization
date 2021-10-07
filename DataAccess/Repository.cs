using Holism.Globalization.Models;
using Holism.DataAccess;

namespace Holism.Globalization.DataAccess
{
    public class Repository
    {
        public static Repository<Locale> Locale
        {
            get
            {
                return new Holism.DataAccess.Repository<Locale
                >(new GlobalizationContext());
            }
        }

        public static Repository<Text> Text
        {
            get
            {
                return new Holism.DataAccess.Repository<Text
                >(new GlobalizationContext());
            }
        }

        public static Repository<Translation> Translation
        {
            get
            {
                return new Holism.DataAccess.Repository<Translation
                >(new GlobalizationContext());
            }
        }

        public static Repository<TranslationView> TranslationView
        {
            get
            {
                return new Holism.DataAccess.Repository<TranslationView
                >(new GlobalizationContext());
            }
        }
    }
}
