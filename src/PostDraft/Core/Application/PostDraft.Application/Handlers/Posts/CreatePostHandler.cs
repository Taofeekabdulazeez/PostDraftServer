
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PostDraft.Application.Commands.Posts;
using PostDraft.Domain.Contracts;
using PostDraft.Domain.Entities;
using PostDraft.Infrastructure.Repositories;
using System.Text.Json;

namespace PostDraft.Application.Handlers.Posts
{
    public class CreatePostHandler : IRequestHandler<CreatePostCommand, ApiResponse>
    {
        private readonly PostRepository postRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreatePostHandler> _logger;

        public CreatePostHandler(PostRepository repository, IMapper mapper, ILogger<CreatePostHandler> logger)
        {
            postRepository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ApiResponse> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var post = _mapper.Map<Post>(request.CreatePostRequest);
            _logger.LogInformation("Creating a new post with title: {@Post}", JsonSerializer.Serialize(post));

            var newPost = await postRepository.AddAsync(post);

            return new ApiResponse()
            {
                Message = "Post successfully created",
                Status = 201,
                Data = newPost 
            };
        }
    }
}
