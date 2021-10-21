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
    public class TextBusiness : Business<Text, Text>
    {
        protected override Repository<Text> WriteRepository =>
            Repository.Text;

        protected override ReadRepository<Text> ReadRepository =>
            Repository.Text;

        public Text CreateOrGet(string text)
        {
            var dbText = ReadRepository.Get(i => i.Key.ToLower() == text.ToLower());
            if  (dbText != null)
            {
                return dbText;
            }
            dbText = new Text();
            dbText.Key = text;
            Create(dbText);
            return dbText;
        }
    }
}
