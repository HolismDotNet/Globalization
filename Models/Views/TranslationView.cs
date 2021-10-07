namespace Holism.Globalization.Models
{
    public class TranslationView : Holism.Models.IEntity
    {
        public TranslationView()
        {
            RelatedItems = new System.Dynamic.ExpandoObject();
        }

        public long Id { get; set; }

        public long TextId { get; set; }

        public long LocaleId { get; set; }

        public string Value { get; set; }

        public string TextKey { get; set; }

        public string Locale { get; set; }

        public dynamic RelatedItems { get; set; }
    }
}
