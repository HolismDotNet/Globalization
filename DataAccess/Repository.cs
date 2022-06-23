namespace Globalization;

public class Repository
{
    public static Write<Globalization.EntityLocale> EntityLocale
    {
        get
        {
            return new Write<Globalization.EntityLocale>(new GlobalizationContext());
        }
    }

    public static Write<Globalization.Locale> Locale
    {
        get
        {
            return new Write<Globalization.Locale>(new GlobalizationContext());
        }
    }

    public static Write<Globalization.Text> Text
    {
        get
        {
            return new Write<Globalization.Text>(new GlobalizationContext());
        }
    }

    public static Write<Globalization.Translation> Translation
    {
        get
        {
            return new Write<Globalization.Translation>(new GlobalizationContext());
        }
    }

    public static Write<Globalization.TranslationView> TranslationView
    {
        get
        {
            return new Write<Globalization.TranslationView>(new GlobalizationContext());
        }
    }

    public static Write<Globalization.UserChoice> UserChoice
    {
        get
        {
            return new Write<Globalization.UserChoice>(new GlobalizationContext());
        }
    }
}
