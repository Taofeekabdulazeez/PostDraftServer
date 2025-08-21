
namespace PostDraft.Domain.Contracts
{
    public class ApiResponse
    {
        public int? Status { get; set; }

        public string? Message { get; set; }

        public object? Data { get; set; }


        public static ApiResponse Created(string? message = "Success", object? data = null)
        {
            return new ApiResponse
            {
                Message = message,
                Data = data,
                Status = 201
            };
        }


        public static ApiResponse Ok(string? message = "Success", object? data = null)
        {
            return new ApiResponse
            {
                Message = message,
                Data = data,
                Status = 200
            };
        }

        public static ApiResponse Notfound(string? message = "Not found")
        {
            return new ApiResponse
            {
                Message = message,
                Data = null,
                Status = 404
            };
        }
    }
}

