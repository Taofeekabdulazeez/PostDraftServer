using MediatR;
using PostDraft.Application.Queries.Post;
using PostDraft.Domain.Contracts;
using PostDraft.Infrastructure.Repositories;

namespace PostDraft.Application.Handlers.Posts
{
    public class GetAllPostsHandler: IRequestHandler<GetAllPostsQuery, ApiResponse>
    {
        private readonly PostRepository repository;

        public GetAllPostsHandler(PostRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ApiResponse> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
        {
            var posts = await repository.GetAllAsync();

            return new ApiResponse()
            {
                Message = "Success",
                Status = 200,
                Data = posts
            };
        }
    }
}
