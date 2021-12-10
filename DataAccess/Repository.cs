namespace Holism.Globalization.DataAccess;

public class Repository
{
    public static Repository<Locale> Locale
    {
        get
        {
            return new Repository<Locale>(new GlobalizationContext());
        }
    }

    public static Repository<Text> Text
    {
        get
        {
            return new Repository<Text>(new GlobalizationContext());
        }
    }

    public static Repository<Translation> Translation
    {
        get
        {
            return new Repository<Translation>(new GlobalizationContext());
        }
    }

    public static Repository<TranslationView> TranslationView
    {
        get
        {
            return new Repository<TranslationView>(new GlobalizationContext());
        }
    }
}
