using Account.Domain.Common;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Account.Api.Extensions
{
    public static class ControllerBaseExtensions
    {
        public static ObjectResult Problem(this ControllerBase controller, Error? error)
        {
            Activity? activity = controller.HttpContext.Features.Get<IHttpActivityFeature>()?.Activity;

            var problemDetails = controller.ProblemDetailsFactory.CreateProblemDetails(controller.HttpContext, 400, "Error");
            if (error != null)
            {
                problemDetails.Title = "An error occured";
                problemDetails.Detail = error.Value.Description;
                problemDetails.Status = ToStatusCode(error.Value.Type);
                problemDetails.Instance = $"{controller.HttpContext.Request.Method} {controller.HttpContext.Request.Path}";
                problemDetails.Extensions["code"] = error.Value.Code;
                problemDetails.Extensions["requestId"] = controller.HttpContext.TraceIdentifier;
                problemDetails.Extensions["traceId"] = activity?.Id;
            }

            return new ObjectResult(problemDetails);
        }

        private static int? ToStatusCode(ErrorType type) => type switch
        {
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            _ => StatusCodes.Status500InternalServerError
        };
    }
}