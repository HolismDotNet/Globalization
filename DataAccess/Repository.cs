namespace Globalization;

public class Repository
{
    public static Repository<Globalization.Locale> Locale
    {
        get
        {
            return new Repository<Globalization.Locale>(new GlobalizationContext());
        }
    }

    public static Repository<Globalization.Text> Text
    {
        get
        {
            return new Repository<Globalization.Text>(new GlobalizationContext());
        }
    }

    public static Repository<Globalization.Translation> Translation
    {
        get
        {
            return new Repository<Globalization.Translation>(new GlobalizationContext());
        }
    }

    public static Repository<Globalization.TranslationView> TranslationView
    {
        get
        {
            return new Repository<Globalization.TranslationView>(new GlobalizationContext());
        }
    }
}
