using MediatR;
using PostDraft.Domain.Contracts;
using PostDraft.Application.Queries.Post;
using PostDraft.Infrastructure.Repositories;

namespace PostDraft.Application.Handlers.Posts
{
    public class GetPostsByCategoryHandler : IRequestHandler<GetPostsByCategoryQuery, ApiResponse>
    {
        private readonly PostRepository _repository;
    
        public GetPostsByCategoryHandler(PostRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse> Handle(GetPostsByCategoryQuery request, CancellationToken cancellationToken)
        {
            var posts = await _repository.GetPostsByCategory(request.PostCategory!);

            return new ApiResponse()
            {
                Status = 200,
                Message = "Success",
                Data = posts
            };
        }
    }
}
