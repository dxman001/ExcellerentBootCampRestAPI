using Microsoft.EntityFrameworkCore;
using RestAPICompleted.Models;


namespace RestAPICompleted.DBContext
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<MemberEntity> Member { get; set; }
    }
}
