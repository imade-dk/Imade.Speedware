using Imade.Speedware.Api.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Imade.Speedware.TestApi.Filters;

public class SpeedwareExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is SpeedwareApiException ex)
        {
            var status = (int)(ex.StatusCode ?? HttpStatusCode.InternalServerError);
            context.Result = new ObjectResult(ex.Message) { StatusCode = status };
        }
        else
        {
            context.Result = new ObjectResult(context.Exception.Message)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }
        context.ExceptionHandled = true;
    }
}
