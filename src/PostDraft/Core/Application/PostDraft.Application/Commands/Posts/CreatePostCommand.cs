
using MediatR;
using PostDraft.Domain.Contracts;

namespace PostDraft.Application.Commands.Posts
{
    public class CreatePostCommand: IRequest<ApiResponse>
    {
        public CreatePostRequest? CreatePostRequest { get; set; }
    }
}
