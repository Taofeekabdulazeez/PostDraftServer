using AutoMapper;
using MediatR;
using PostDraft.Application.Queries.Post;
using PostDraft.Domain.Contracts;
using PostDraft.Domain.Entities;
using PostDraft.Infrastructure.Interface;

namespace PostDraft.Application.Handlers.Posts
{
    public class GetAllPostsHandler: IRequestHandler<GetAllPostsQuery, ApiResponse>
    {
        private readonly IRepository<Post> repository;
        private readonly IMapper _mapper;

        public GetAllPostsHandler(IRepository<Post> repository, IMapper mapper)
        {
            this.repository = repository;
            this._mapper = mapper;
        }

        public async Task<ApiResponse> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
        {
            await Task.Delay(2000);

            ICollection<Post> posts = [
                new Post
            {
                Id = 1,
                Title = "How to optimize linkedIn profile",
                Description = "Description",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Category = "linkedIn",
                Link = "https://www.linkedin.com/u/TaofeekAbdulazeez",
            }, new Post
            {
                Id = 2,
                Title = "How to monetize your skills",
                Description = "Description",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Category = "youtube",
                Link = "https://youtube.com/TaofeekAbdulazeez",
            }
             ];

            return new ApiResponse()
            {
                Message = "Success",
                Status = 200,
                Data = posts
            };
        }
    }
}
