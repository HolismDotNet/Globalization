namespace Globalization;

public class TranslationBusiness : Business<TranslationView, Translation>
{
    protected override Write<Translation> Write => Repository.Translation;

    protected override Read<TranslationView> Read => Repository.TranslationView;

    public List<TranslationView> GetTranslations(long localeId)
    {
        var translations = GetList(i => i.LocaleId == localeId);
        return translations;
    }

    public TranslationView Create(TranslationView translation)
    {
        var text = new TextBusiness().CreateOrGet(translation.TextKey);
        var dbTransaltion = Get(i => i.TextId == text.Id && i.LocaleId == translation.LocaleId);
        if (dbTransaltion == null)
        {
            translation.TextId = text.Id;
            var result = Create(translation.CastTo<Translation>());
            return Get(result.Id);
        }
        else
        {
            if (dbTransaltion.Value != translation.Value)
            {
                dbTransaltion.Value = translation.Value;
                Update(translation.CastTo<Translation>());
                return Get(dbTransaltion.Id);
            }
            return dbTransaltion;
        }
    }

    public TranslationView Create(string text, string localeKey, string translation)
    {
        var result = Create(new TranslationView
        {
            TextKey = text,
            LocaleId = new LocaleBusiness().GetByKey(localeKey).Id,
            Value = translation
        });
        return result;
    }

    // protected override void PostDeletion(Translation translation)
    // {
    //     new TextBusiness().Delete(translation.TextId);
    // }
}
