
using MediatR;
using PostDraft.Domain.Contracts;

namespace PostDraft.Application.Commands.Posts
{
    public class UpdatePostCommand: IRequest<ApiResponse>
    {
        public int PostId { get; set; }

        public UpdatePostRequest? UpdatePostRequest { get; set; }
    }
}
