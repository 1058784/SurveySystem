using SurveySystem.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SurveySystem.DAL
{
    public class SurveyContext : DbContext
    {
        public SurveyContext() : base("SurveyContext")
        {
        }

        public DbSet<Respondent> Respondents { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<MultiChoise> MultiChoises { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}