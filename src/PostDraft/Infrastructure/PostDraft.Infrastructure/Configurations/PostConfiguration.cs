

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostDraft.Domain.Entities;

namespace PostDraft.Infrastructure.Configurations
{
    public class PostConfiguration: IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Title).IsRequired();
            builder.Property(c => c.Description);
            builder.Property(c => c.Category).IsRequired();

            builder.HasData(new Post
            {
                Id = 1,
                Title = "How to optimize linkedIn profile",
                Description = "Description",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Category = "linkedIn",
                Link = "https://www.linkedin.com/u/TaofeekAbdulazeez",
            }, new Post
            {
                Id = 2,
                Title = "How to monetize your skills",
                Description = "Description",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Category = "youtube",
                Link = "https://youtube.com/TaofeekAbdulazeez",
            });
        }
    }
}
