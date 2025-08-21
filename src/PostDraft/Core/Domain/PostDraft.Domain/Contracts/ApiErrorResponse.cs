namespace PostDraft.Domain.Contracts
{
    public class ApiErrorResponse
    {
        public string Message { get; set; } = string.Empty;
        public int StatusCode { get; set; }
        public string Title { get; set; } = string.Empty;
    }
}
