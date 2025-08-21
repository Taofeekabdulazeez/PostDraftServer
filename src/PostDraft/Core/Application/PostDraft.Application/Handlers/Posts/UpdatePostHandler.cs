

using AutoMapper;
using MediatR;
using PostDraft.Application.Commands.Posts;
using PostDraft.Domain.Contracts;
using PostDraft.Domain.Entities;
using PostDraft.Infrastructure.Interface;

namespace PostDraft.Application.Handlers.Posts
{
    public class UpdatePostHandler : IRequestHandler<UpdatePostCommand, ApiResponse>
    {
        private readonly IRepository<Post> repository;
        private readonly IMapper _mapper;

        public UpdatePostHandler(IRepository<Post> repository, IMapper mapper)
        {
            this.repository = repository;
            this._mapper = mapper;
        }
        public async Task<ApiResponse> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            await Task.Delay(200);

            var post = _mapper.Map<Post>(request.UpdatePostRequest);

            return new ApiResponse()
            {
                Message = "Post successfully updated!",
                Status = 200,
                Data = post
            };
        }
    }
}
