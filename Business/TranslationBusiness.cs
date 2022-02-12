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
        translation.TextId = text.Id;
        var result = Create(translation.CastTo<Translation>());
        return Get(result.Id);
    }

    // protected override void PostDeletion(Translation translation)
    // {
    //     new TextBusiness().Delete(translation.TextId);
    // }
}
