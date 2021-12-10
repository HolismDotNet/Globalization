using System.Collections.Generic;
using Holism.Globalization.Models;
using Holism.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Holism.Globalization.DataAccess
{
    public class GlobalizationContext : DatabaseContext
    {
        public override string ConnectionStringName => "Globalization";

        public DbSet<Locale> Locales { get; set; }

        public DbSet<Text> Texts { get; set; }

        public DbSet<Translation> Translations { get; set; }

        public DbSet<TranslationView> TranslationViews { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            base.OnModelCreating(builder);
        }
    }
}
