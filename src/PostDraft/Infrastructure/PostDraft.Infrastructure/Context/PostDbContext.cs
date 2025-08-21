using Microsoft.EntityFrameworkCore;
using PostDraft.Domain.Entities;

namespace PostDraft.Infrastructure.Context
{
    public class PostDbContext(DbContextOptions<PostDbContext> options) : DbContext(options)
    {
        public DbSet<Post> Posts => Set<Post>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PostDbContext).Assembly);
        }
    }
}
