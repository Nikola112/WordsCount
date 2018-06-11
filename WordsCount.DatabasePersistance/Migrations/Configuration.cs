namespace WordsCount.DatabasePersistance.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<WordsCountDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WordsCountDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Sentences.AddOrUpdate(new Core.Domain.Sentence()
            {
                Text = "Hello World!",
                NumberOfWords = 2
            });
        }
    }
}
