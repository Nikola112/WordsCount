using System.Data.Entity;
using WordsCount.Core.Domain;

namespace WordsCount.DatabasePersistance
{
    public class WordsCountDbContext : DbContext
    {
        #region Properties

        public DbSet<Sentence> Sentences { get; set; }

        #endregion

        #region Methods

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sentence>()
                .Property(s => s.Text)
                .IsUnicode()
                .IsRequired()
                .HasMaxLength(2048);

            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}
