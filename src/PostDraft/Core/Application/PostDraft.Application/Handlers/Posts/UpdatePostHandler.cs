

using Microsoft.Extensions.Logging;
using AutoMapper;
using MediatR;
using PostDraft.Application.Commands.Posts;
using PostDraft.Domain.Contracts;
using PostDraft.Domain.Entities;
using PostDraft.Infrastructure.Repositories;
using System.Text.Json;
using PostDraft.Application.Exceptions;

namespace PostDraft.Application.Handlers.Posts
{
    public class UpdatePostHandler : IRequestHandler<UpdatePostCommand, ApiResponse>
    {
        private readonly PostRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdatePostHandler> _logger;

        public UpdatePostHandler(PostRepository repository, IMapper mapper, ILogger<UpdatePostHandler> logger)
        {
            _repository = repository;
            this._mapper = mapper;
            _logger = logger;
        }
        public async Task<ApiResponse> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Request Data: {Post}", JsonSerializer.Serialize(request.UpdatePostRequest));

            var existingPost = await _repository.GetByIdAsync(request.PostId);

            if (existingPost == null) throw new ResourceNotFoundException("Post Not Found");
               
            _logger.LogInformation("Existing Post before mapping: {Post}", JsonSerializer.Serialize(existingPost));

            _mapper.Map(request.UpdatePostRequest, existingPost);
            _logger.LogInformation("Existing Post after mapping: {Post}", JsonSerializer.Serialize(existingPost));

            var updatedPost = await _repository.UpdateAsync(existingPost);

            return new ApiResponse()
            {
                Message = "Post successfully updated!",
                Status = 200,
                Data = updatedPost
            };
        }
    }
}
