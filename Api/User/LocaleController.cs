namespace Globalization;

public class LocaleController : HolismController
{
    [HttpGet]
    public List<Locale> Actives()
    {
        var activeLocales = new LocaleBusiness().GetActiveLocales();
        return activeLocales;
    }

    [HttpGet]
    public object Data()
    {
        var data = new LocaleBusiness().GetData(Locale);
        return data;
    }
}
