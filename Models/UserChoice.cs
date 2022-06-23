namespace Globalization;

public class UserChoice : IEntity
{
    public UserChoice()
    {
        RelatedItems = new ExpandoObject();
    }

    public long Id { get; set; }

    public Guid UserGuid { get; set; }

    public long LocaleId { get; set; }

    public DateTime UtcDateTimeLocale { get; set; }

    public string Numbers { get; set; }

    public string Currency { get; set; }

    public dynamic RelatedItems { get; set; }
}
