namespace Holism.Globalization.Models
{
    public class Text : Holism.Models.IEntity
    {
        public Text()
        {
            RelatedItems = new System.Dynamic.ExpandoObject();
        }

        public long Id { get; set; }

        public string Key { get; set; }

        public dynamic RelatedItems { get; set; }
    }
}
