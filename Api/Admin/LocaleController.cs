using Holism.Globalization.Business;
using Holism.Globalization.Models;
using Holism.Api;
using Holism.Business;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Collections.Generic;

namespace Holism.Globalization.AdminApi
{
    public class LocaleController : ClientLookupReadController<Locale>
    {
        public override ReadBusiness<Locale> ReadBusiness =>
            new LocaleBusiness();

        [HttpPost]
        public Locale ToggleIsActive(long id)
        {
            var locale = new LocaleBusiness().ToggleIsActive(id);
            return locale;
        }

        [HttpGet]
        public List<Locale> Actives()
        {
            var activeLocales = new LocaleBusiness().GetActiveLocales();
            return activeLocales;
        }

        [HttpGet]
        public object Translations()
        {
            var translations = new LocaleBusiness().GetTranslations(Locale);
            return translations;
        }

        [HttpGet]
        public object Data()
        {
            var data = new LocaleBusiness().GetData(Locale);
            return data;
        }
    }
}
