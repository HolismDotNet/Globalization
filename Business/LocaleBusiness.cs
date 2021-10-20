using System;
using System.Linq.Expressions;
using Holism.Business;
using Holism.DataAccess;
using Holism.Infra;
using Holism.Globalization.DataAccess;
using Holism.Globalization.Models;
using Humanizer;

namespace Holism.Globalization.Business
{
    public class LocaleBusiness : Business<Locale, Locale>
    {
        protected override Repository<Locale> WriteRepository =>
            Repository.Locale;

        protected override ReadRepository<Locale> ReadRepository =>
            Repository.Locale;

        public Locale ToggleIsActive(long id)
        {
            var locale = Get(id);
            locale.IsActive = !locale.IsActive;
            Update(locale);
            return locale;
        }
    }
}
