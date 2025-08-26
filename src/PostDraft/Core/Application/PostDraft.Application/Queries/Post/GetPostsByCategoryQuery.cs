
using MediatR;
using PostDraft.Domain.Contracts;

namespace PostDraft.Application.Queries.Post
{
    public class GetPostsByCategoryQuery: IRequest<ApiResponse>
    {
        public string? PostCategory;
    }
}
