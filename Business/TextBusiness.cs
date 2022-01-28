namespace Globalization;

public class TextBusiness : Business<Text, Text>
{
    protected override Repository<Text> WriteRepository => Repository.Text;

    protected override ReadRepository<Text> ReadRepository => Repository.Text;

    public Text CreateOrGet(string text)
    {
        var key = text.Camelize();
        var dbText = ReadRepository.Get(i => i.Key == key);
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
