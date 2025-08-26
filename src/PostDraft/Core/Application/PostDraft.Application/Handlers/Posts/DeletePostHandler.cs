

using MediatR;
using PostDraft.Application.Commands.Posts;
using PostDraft.Domain.Contracts;
using PostDraft.Infrastructure.Repositories;

namespace PostDraft.Application.Handlers.Posts
{
    public class DeletePostHandler(PostRepository postRepository) : IRequestHandler<DeletePostCommand, ApiResponse>
    {
        public async Task<ApiResponse> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var post = await postRepository.GetByIdAsync(request.Id);

            if (post is null)
            {
                return new ApiResponse()
                {
                    Message = $"Post with ID:{request.Id} not found",
                    Status = 404,
                    Data = null
                };
            }

            await postRepository.DeleteAsync(post);

            return new ApiResponse()
            {
                Message = $"Post with ID:{request.Id} successfully deleted",
                Status = 200,
                Data = post
            };
        }
    }
}
