namespace Holism.Globalization.Models
{
    public class Translation : Holism.Models.IEntity
    {
        public Translation()
        {
            RelatedItems = new System.Dynamic.ExpandoObject();
        }

        public long Id { get; set; }

        public long TextId { get; set; }

        public long LocaleId { get; set; }

        public string Value { get; set; }

        public dynamic RelatedItems { get; set; }
    }
}
