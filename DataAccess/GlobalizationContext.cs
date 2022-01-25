namespace Globalization;

public class GlobalizationContext : DatabaseContext
{
    public override string ConnectionStringName => "Globalization";

    public DbSet<Globalization.Locale> Locales { get; set; }

    public DbSet<Globalization.Text> Texts { get; set; }

    public DbSet<Globalization.Translation> Translations { get; set; }

    public DbSet<Globalization.TranslationView> TranslationViews { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
