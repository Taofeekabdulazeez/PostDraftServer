using AutoMapper;
using MediatR;
using PostDraft.Application.Queries.Post;
using PostDraft.Domain.Contracts;
using PostDraft.Domain.Entities;
using PostDraft.Infrastructure.Interface;
using PostDraft.Application.Exceptions;

namespace PostDraft.Application.Handlers.Posts
{
    public class GetPostByIdHandler : IRequestHandler<GetPostByIdQuery, ApiResponse>
    {
        private readonly IRepository<Post> repository;
        private readonly IMapper _mapper;

        public GetPostByIdHandler(IRepository<Post> repository, IMapper mapper)
        {
            this.repository = repository;
            this._mapper = mapper;
        }

        public async Task<ApiResponse> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
        {
            await Task.Delay(1000);
            var post = new Post()
            {
                Id = request.PostId,
                Title = "How to optimize linkedIn profile",
                Description = "Description",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Category = "linkedIn",
                Link = "https://www.linkedin.com/u/TaofeekAbdulazeez",
            };

            if (request.PostId == 0)
                throw new ResourceNotFoundException("Todo Not found");

            return new ApiResponse()
            {
                Message = "Success",
                Status = 200,
                Data = post
            };
        }
    }
}
