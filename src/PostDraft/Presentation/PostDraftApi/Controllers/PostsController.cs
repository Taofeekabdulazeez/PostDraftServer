using Microsoft.AspNetCore.Mvc;
using PostDraft.Application.Commands.Posts;
using PostDraft.Application.Queries.Post;
using PostDraft.Domain.Contracts;

namespace PostDraftApi.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class PostsController : ApiController
    {
        [HttpGet("posts")]
        public async Task<IActionResult> GetAllPosts()
        {
            return Ok(await _mediator.Send(new GetAllPostsQuery() { }));
        }

        [HttpGet("posts/{id}")]
        public async Task<IActionResult> GetPostById(int id)
        {
            return Ok(await _mediator.Send(new GetPostByIdQuery { PostId = id }));
        }

        [HttpPost("posts")]
        public async Task<IActionResult> CreatePost([FromBody] CreatePostRequest data)
        {
            var response = await _mediator.Send(new CreatePostCommand
            {
               CreatePostRequest = data
            });

            return Ok(response);
        }

        [HttpPatch("todos/{id}")]
        public async Task<IActionResult> UpdatePost(int id, [FromBody] UpdatePostRequest data)
        {
            var response = await _mediator.Send(new UpdatePostCommand
            {
                PostId = id,
                UpdatePostRequest = data
            });

            return Ok(response);
        }

        [HttpDelete("posts/{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            return Ok(await _mediator.Send(new DeletePostCommand { Id = id }));
        }
    }
}
