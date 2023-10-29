using System.Net;

namespace SprintPlanning.ExternalServices.Base
{
    public class HttpResult<T>
    {
        public HttpResult()
        { }

        public HttpResult(T value, HttpStatusCode statusCode)
        {
            Value = value;
            StatusCode = statusCode;
        }

        public HttpResult(T? value)
        {
            Value = value;
            StatusCode = null;
        }

        public HttpResult(HttpStatusCode? statusCode)
        {
            Value = default;
            StatusCode = statusCode;
        }

        public T? Value { get; }
        public HttpStatusCode? StatusCode { get; }

    }
}
