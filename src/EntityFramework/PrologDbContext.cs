using Microsoft.EntityFrameworkCore;
using Prolog.Model;

namespace Prolog.EntityFramework
{
    public class PrologDbContext : DbContext
    {
        public DbSet<Atom> Atoms { get; set; }
        public DbSet<BinaryExpression> BinaryExpressions { get; set; }
        public DbSet<Expression> Expressions { get; set; }
        public DbSet<Fact> Facts { get; set; }
        public DbSet<Rule> Rules { get; set; }
        public DbSet<Variable> Variables { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=app.db");
        }
    }
}