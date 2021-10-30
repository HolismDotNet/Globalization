using Holism.Globalization.Business;
using Holism.Globalization.Models;
using Holism.Api;
using Holism.Business;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Collections.Generic;

namespace Holism.Globalization.UserApi
{
    public class LocaleController : HolismController
    {
        [HttpGet]
        public List<Locale> Actives()
        {
            var activeLocales = new LocaleBusiness().GetActiveLocales();
            return activeLocales;
        }

        [HttpGet]
        public object Data()
        {
            var data = new LocaleBusiness().GetData(Locale);
            return data;
        }
    }
}
