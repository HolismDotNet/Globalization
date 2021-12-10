namespace Holism.Globalization.Models;

public class Translation : IEntity
{
    public Translation()
    {
        RelatedItems = new ExpandoObject();
    }

    public long Id { get; set; }

    public long TextId { get; set; }

    public long LocaleId { get; set; }

    public string Value { get; set; }

    public dynamic RelatedItems { get; set; }
}
