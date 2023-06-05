using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace InsiteTeamTask.API.Extentions
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            // Handle different types of exceptions and set appropriate results

            switch (context.Exception)
            {
                case ArgumentException:
                    // If an ArgumentException occurs, set the result to a BadRequestResult,
                    // indicating a client-side error in the request.
                    context.Result = new BadRequestResult();
                    break;
                case InvalidOperationException:
                    // If an InvalidOperationException occurs, set the result to a NotFoundResult,
                    // indicating that the requested resource could not be found.
                    context.Result = new NotFoundResult();
                    break;
                default:
                    // For any other types of exceptions, no specific result is set.
                    // The exception will be handled by the default exception handling mechanism.
                    break;
            }
        }
    }
}
