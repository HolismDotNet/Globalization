using Holism.Globalization.DataAccess;

namespace Holism.Globalization.Business;

public class LocaleBusiness : Business<Locale, Locale>
{
    public const string Pattern = "language-region-script";

    protected override Repository<Locale> WriteRepository =>
        Repository.Locale;

    protected override ReadRepository<Locale> ReadRepository =>
        Repository.Locale;

    private static Dictionary<string, object> translationsDictionary = new Dictionary<string, object>();

    public static Dictionary<string, object> TranslationsCache
    {
        get
        {
            if (translationsDictionary == null)
            {
                translationsDictionary = new Dictionary<string, object>();
            }
            return translationsDictionary;
        }
    }

    public static void DeleteCache()
    {
        translationsDictionary = null;
    }

    public Locale ToggleIsActive(long id)
    {
        var locale = Get(id);
        locale.IsActive = !locale.IsActive;
        Update(locale);
        return locale;
    }

    public List<Locale> GetActiveLocales()
    {
        var activeLocales = GetList(i => i.IsActive == true);
        return activeLocales;
    }

    public override Locale GetByKey(string key)
    {
        var locale = Get(i => i.Key.ToLower() == key.ToLower());
        return locale;
    }

    public object GetTranslations(string locale)
    {
        if(TranslationsCache.ContainsKey(locale))
        {
            return TranslationsCache[locale];
        }
        dynamic entry = new ExpandoObject();
        var localObject = GetByKey(locale);
        var translations = new TranslationBusiness().GetTranslations(localObject.Id);
        foreach (var translation in translations)
        {
            ExpandoObjectExtensions.AddProperty(entry, translation.TextKey, translation.Value);
        }
        translationsDictionary.Add(locale, entry);
        return entry;
    }

    public object GetData(string locale)
    {
        dynamic data = new ExpandoObject();
        data.Locale = GetByKey(locale);
        data.Translations = GetTranslations(locale);
        return data;
    }
}
