namespace Globalization;

public class Locale : IEntity
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

    public dynamic RelatedItems { get; set; }
}
