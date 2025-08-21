
using AutoMapper;
using MediatR;
using PostDraft.Application.Commands.Posts;
using PostDraft.Domain.Contracts;
using PostDraft.Domain.Entities;
using PostDraft.Infrastructure.Interface;

namespace PostDraft.Application.Handlers.Posts
{
    public class CreatePostHandler : IRequestHandler<CreatePostCommand, ApiResponse>
    {
        private readonly IRepository<Post> repository;
        private readonly IMapper _mapper;

        public CreatePostHandler(IRepository<Post> repository, IMapper mapper)
        {
            this.repository = repository;
            this._mapper = mapper;
        }

        public async Task<ApiResponse> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var post = _mapper.Map<Post>(request.CreatePostRequest);
            //post.Id = ;
            post.CreatedAt = DateTime.Now;
            post.UpdatedAt = DateTime.Now;

            await Task.Delay(2000);

            return new ApiResponse()
            {
                Message = "Post successfully created",
                Status = 201,
                Data = post 
            };
        }
    }
}
