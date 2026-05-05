using System;
using System.Net;

namespace Imade.Speedadmin.Api.Core
{
    public class SpeedwareApiException : Exception
    {
        public HttpStatusCode? StatusCode { get; }

        public SpeedwareApiException(string message) : base(message) { }

        public SpeedwareApiException(string message, HttpStatusCode statusCode) : base(message)
        {
            StatusCode = statusCode;
        }

        public SpeedwareApiException(string message, Exception inner) : base(message, inner) { }
    }
}
