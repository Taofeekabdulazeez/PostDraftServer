using Microsoft.AspNetCore.Mvc;
using PostDraft.Application.Commands.Posts;
using PostDraft.Application.Queries.Post;
using PostDraft.Domain.Contracts;

namespace PostDraftApi.Controllers
{
    [ApiController]
    [Route("api/posts")]
    public class PostsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllPosts([FromQuery] string? category )
        {
            if (!string.IsNullOrEmpty(category) && !category.Equals("all", StringComparison.OrdinalIgnoreCase))
            {
                return Ok(await _mediator.Send(new GetPostsByCategoryQuery()
                {
                    PostCategory = category.Trim(),
                }));
            }
                
            return Ok(await _mediator.Send(new GetAllPostsQuery() { }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostById(int id)
        {
            return Ok(await _mediator.Send(new GetPostByIdQuery { PostId = id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] CreatePostRequest data)
        {
            var response = await _mediator.Send(new CreatePostCommand
            {
               CreatePostRequest = data
            });

            return Ok(response);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdatePost(int id, [FromBody] UpdatePostRequest data)
        {
            var response = await _mediator.Send(new UpdatePostCommand
            {
                PostId = id,
                UpdatePostRequest = data
            });

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            return Ok(await _mediator.Send(new DeletePostCommand { Id = id }));
        }
    }
}
