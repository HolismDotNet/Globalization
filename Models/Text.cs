namespace Globalization;

public class Text : IEntity
{
    public Text()
    {
        RelatedItems = new ExpandoObject();
    }

    public long Id { get; set; }

    public string Key { get; set; }

    public string OriginalText { get; set; }

    public dynamic RelatedItems { get; set; }
}
