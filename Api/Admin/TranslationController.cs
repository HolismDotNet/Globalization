using Holism.Api;
using Holism.Business;
using Holism.Globalization.Business;
using Holism.Globalization.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Holism.Globalization.AdminApi
{
    public class TranslationController : ReadController<TranslationView>
    {
        public override ReadBusiness<TranslationView> ReadBusiness => new TranslationBusiness();
        
        [HttpPost]
        public IActionResult Create(TranslationView translation)
        {
            var result = new TranslationBusiness().Create(translation);
            return CreationJson(result);
        }

        [HttpPost]
        public IActionResult Delete(long id)
        {
            new TranslationBusiness().Delete(id);
            return DeletionJson();
        }
    }
}