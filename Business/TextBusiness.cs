namespace Globalization;

public class TextBusiness : Business<Text, Text>
{
    protected override Write<Text> Write => Repository.Text;

    protected override Read<Text> Read => Repository.Text;

    public Text CreateOrGet(string text)
    {
        text = Regex.Replace(text, @"[^\w ]", "");
        var key = text.Camelize();
        var dbText = Read.Get(i => i.Key == key);
        if  (dbText != null)
        {
            dbText.Key = key;
            dbText.OriginalText = text;
            Update(dbText);
            return dbText;
        }
        dbText = new Text();
        dbText.Key = key;
        dbText.OriginalText = text;
        Create(dbText);
        return dbText;
    }
}
