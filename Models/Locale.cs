namespace Globalization;

public class Locale : IEntity, IKey
{
    public Locale()
    {
        RelatedItems = new ExpandoObject();
    }

    public long Id { get; set; }

    public string Key { get; set; }

    public string LocalKey { get; set; }

    public bool? IsRtl { get; set; }

    public bool IsActive { get; set; }

    public Guid? CountryGuid { get; set; }

    public string TimeZoneIdentifier { get; set; }

    public bool? SupportsLetterSpacing { get; set; }

    public string LanguageRegionScript { get; set; }

    public string Iso { get; set; }

    public dynamic RelatedItems { get; set; }
}
