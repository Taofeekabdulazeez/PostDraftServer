

using MediatR;
using PostDraft.Domain.Contracts;

namespace PostDraft.Application.Commands.Posts
{
    public class DeletePostCommand: IRequest<ApiResponse>
    {
        public int Id { get; set; }
    }
}
