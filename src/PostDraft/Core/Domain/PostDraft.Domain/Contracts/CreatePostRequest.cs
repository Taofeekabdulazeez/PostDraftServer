
namespace PostDraft.Domain.Contracts
{
    public class CreatePostRequest
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Link { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
    }
}
