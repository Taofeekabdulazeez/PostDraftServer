

using MediatR;
using PostDraft.Application.Commands.Posts;
using PostDraft.Domain.Contracts;

namespace PostDraft.Application.Handlers.Posts
{
    public class DeletePostHandler : IRequestHandler<DeletePostCommand, ApiResponse>
    {
        public async Task<ApiResponse> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            await Task.Delay(2000);

            return new ApiResponse()
            {
                Message = $"Post with ID:{request.Id} successfully deleted",
                Status = 200,
                Data = null
            };
        }
    }
}
