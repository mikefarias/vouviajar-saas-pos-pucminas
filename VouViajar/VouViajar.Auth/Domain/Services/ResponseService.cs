using System.Net;

namespace VouViajar.Auth.Domain.Services
{
    public class ResponseService
    {
        public HttpStatusCode Status { get; set; }
        public bool Success { get; set; } = false;
        public string Message { get; set; }
    }

    public class ResponseService<T> : ResponseService
    {
        public T Value { get; set; }

        public ResponseService<T2> Map<T2>(Func<T, T2> mapper)
        {
            var response = new ResponseService<T2>
            {
                Message = Message,
                Status = Status,
                Success = Success,
            };

            if (Value != null)
            {
                response.Value = mapper(Value);
            }

            return response;
        }
    }
}
