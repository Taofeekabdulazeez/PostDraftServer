
namespace PostDraft.Domain.Contracts
{
    public class UpdatePostRequest
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Category {  get; set; }
    }
}
