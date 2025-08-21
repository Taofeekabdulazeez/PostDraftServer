using MediatR;
using PostDraft.Domain.Contracts;

namespace PostDraft.Application.Queries.Post
{
    public class GetPostByIdQuery: IRequest<ApiResponse>
    {
        public int PostId { get; set; }
    }
}
