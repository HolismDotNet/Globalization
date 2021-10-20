using System;
using System.Linq.Expressions;
using Holism.Business;
using Holism.DataAccess;
using Holism.Infra;
using Holism.Globalization.DataAccess;
using Holism.Globalization.Models;
using Humanizer;
using System.Collections.Generic;

namespace Holism.Globalization.Business
{
    public class TranslationBusiness : Business<TranslationView, Translation>
    {
        protected override Repository<Translation> WriteRepository =>
            Repository.Translation;

        protected override ReadRepository<TranslationView> ReadRepository =>
            Repository.TranslationView;

        public List<TranslationView> GetTranslations(long localeId)
        {
            var translations = GetList(i => i.LocaleId == localeId);
            return translations;
        }

        public 
    }
}
