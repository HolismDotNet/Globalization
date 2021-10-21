using System;

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

        public string LocalKey { get; set; }

        public bool? IsRtl { get; set; }

        public bool IsActive { get; set; }

        public Guid? CountryGuid { get; set; }

        public dynamic RelatedItems { get; set; }
    }
}
