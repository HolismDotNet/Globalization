namespace Globalization;

public class EntityLocale : IEntity
{
    public EntityLocale()
    {
        RelatedItems = new ExpandoObject();
    }

    public long Id { get; set; }

    public Guid EntityTypeGuid { get; set; }

    public Guid EntityGuid { get; set; }

    public long LocaleId { get; set; }

    public dynamic RelatedItems { get; set; }
}
