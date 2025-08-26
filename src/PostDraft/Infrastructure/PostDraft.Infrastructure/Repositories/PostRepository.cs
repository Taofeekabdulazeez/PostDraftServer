

using Microsoft.EntityFrameworkCore;
using PostDraft.Domain.Entities;
using PostDraft.Infrastructure.Context;

namespace PostDraft.Infrastructure.Repositories
{
    public class PostRepository(ApplicationDbContext context) : BaseRepository<Post>(context)
    {
      
        public async Task<List<Post>> GetPostsByCategory(string category) {
            var posts = await _context.Posts.Where(c => c.Category == category).ToListAsync();

            return posts;
        }
    }
}

