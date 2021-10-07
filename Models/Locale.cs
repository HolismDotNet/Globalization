namespace Holism.Globalization.Models
{
    public class Locale : Holism.Models.IEntity
    {
        public Locale()
        {
            RelatedItems = new System.Dynamic.ExpandoObject();
        }

        public long Id { get; set; }

        public string Key { get; set; }

        public dynamic RelatedItems { get; set; }
    }
}
