using AutoMapper;
using MediatR;
using PostDraft.Application.Queries.Post;
using PostDraft.Domain.Contracts;
using PostDraft.Application.Exceptions;
using PostDraft.Infrastructure.Repositories;

namespace PostDraft.Application.Handlers.Posts
{
    public class GetPostByIdHandler : IRequestHandler<GetPostByIdQuery, ApiResponse>
    {
        private readonly PostRepository _repository;
        private readonly IMapper _mapper;

        public GetPostByIdHandler(PostRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ApiResponse> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
        {
            var post = await _repository.GetByIdAsync(request.PostId);

            if (post == null) 
                throw new ResourceNotFoundException($"Post with ID={request.PostId} Not Found!");

            return new ApiResponse()
            {
                Message = "Success",
                Status = 200,
                Data = post
            };
        }
    }
}
