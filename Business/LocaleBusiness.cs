namespace Globalization;

public class LocaleBusiness : Business<Locale, Locale>
{
    public const string Pattern = "language-region-script";

    protected override Write<Locale> Write => Repository.Locale;

    protected override Read<Locale> Read => Repository.Locale;

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

    public void InsertTranslations(List<long> localeIds)
    {
        if (localeIds.Count == 0)
        {
            return;
        }
        var locales = GetList(localeIds);
        var localizationJsonFiles = Directory.GetFiles("/HolismVite/", "Localization.json", SearchOption.AllDirectories);
        foreach (var file in localizationJsonFiles)
        {
            var content = File.ReadAllText(file);
            content.Ensure().IsJson($"File {file} is not JSON").IsJsonArray($"File {file} should be a JSON array");
            InsertTranslations(locales, content);
        }
        translationsDictionary = null;
    }

    private void InsertTranslations(List<Locale> locales, string content)
    {
        var localizations = content.ParseJson().AsArray();
        foreach (var localization in localizations)
        {
            var locale = localization["locale"].ToString();
            if (locales.Any(i => i.Key == locale))
            {
                continue;
            }
            foreach (var item in localization["translations"].AsObject().AsEnumerable())
            {
                InsertTranslation(locale, item.Key, item.Value.ToString());
            }
        }
    }

    private void InsertTranslation(string locale, string text, string translation)
    {
        try
        {
            new TranslationBusiness().Create(text, locale, translation);
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            throw new ServerException($"Can not insert translation {translation} for locale {locale} for text {text}", ex);
        }
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
        if (TranslationsCache.ContainsKey(locale))
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
