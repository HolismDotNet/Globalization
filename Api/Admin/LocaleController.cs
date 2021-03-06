namespace Globalization;

public class LocaleController : ClientLookupReadController<Locale>
{
    public override ReadBusiness<Locale> ReadBusiness =>
        new LocaleBusiness();

    [HttpPost]
    public Locale ToggleIsActive(long id)
    {
        var locale = new LocaleBusiness().ToggleIsActive(id);
        return locale;
    }

    [HttpGet]
    public List<Locale> Actives()
    {
        var activeLocales = new LocaleBusiness().GetActiveLocales();
        return activeLocales;
    }

    [HttpGet]
    public object Translations()
    {
        var translations = new LocaleBusiness().GetTranslations(Locale);
        return translations;
    }

    [HttpGet]
    public object Data()
    {
        var data = new LocaleBusiness().GetData(Locale);
        return data;
    }

    [HttpPost]
    public IActionResult InsertTranslations([FromBody] List<long> localeIds)
    {
        new LocaleBusiness().InsertTranslations(localeIds);
        return OkJson();
    }

    [HttpPost]
    public IActionResult RemoveTranslations([FromBody] List<long> localeIds)
    {
        new LocaleBusiness().RemoveTranslations(localeIds);
        return OkJson();
    }
}
