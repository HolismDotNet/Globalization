using System;
using System.Linq.Expressions;
using Holism.Business;
using Holism.DataAccess;
using Holism.Infra;
using Holism.Globalization.DataAccess;
using Holism.Globalization.Models;
using Humanizer;
using System.Collections.Generic;
using System.Dynamic;

namespace Holism.Globalization.Business
{
    public class LocaleBusiness : Business<Locale, Locale>
    {
        protected override Repository<Locale> WriteRepository =>
            Repository.Locale;

        protected override ReadRepository<Locale> ReadRepository =>
            Repository.Locale;

        private Dictionary<string, object> translationsDictionary = new Dictionary<string, object>();

        public Locale ToggleIsActive(long id)
        {
            var locale = Get(id);
            locale.IsActive = !locale.IsActive;
            Update(locale);
            return locale;
        }

        public List<Locale> GetActiveLocales()
        {
            var activeLocales = GetList(i => i.IsActive == true);
            return activeLocales;
        }

        public Locale GetByKey(string key)
        {
            var locale = Get(i => i.Key.ToLower() == key.ToLower());
            return locale;
        }

        public object GetTranslations(string locale)
        {
            if(translationsDictionary.ContainsKey(locale))
            {
                return translationsDictionary[locale];
            }
            dynamic entry = new ExpandoObject();
            var localObject = GetByKey(locale);
            var translations = new TranslationBusiness().GetTranslations(localObject.Id);
            foreach (var translation in translations)
            {
                ExpandoObjectExtensions.AddProperty(entry, translation.TextKey, translation.Value);
            }
            translationsDictionary.Add(locale, entry);
            return entry;
        }

        public object GetData(string locale)
        {
            dynamic data = new ExpandoObject();
            data.Locale = GetByKey(locale);
            data.Translations = GetTranslations(locale);
            return data;
        }
    }
}
