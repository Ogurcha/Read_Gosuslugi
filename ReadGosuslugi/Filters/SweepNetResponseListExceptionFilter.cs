using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ReadGosuslugi.Controllers.ControllerContracts;
using ReadGosuslugi.Exceptions;
using System;

namespace ReadGosuslugi.Filters
{
    /// <summary>
    /// Handles exception if exception is type of <see cref="ManagedExceptionBase"/> 
    /// and wraps result in <see cref="SweepNetResponse"/>
    /// </summary>
    public class SweepNetResponseExceptionFilterAttribute : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is ManagedExceptionBase e)
            {
                context.Result = new OkObjectResult(new SweepNetResponse()
                {
                    ResultCode = e.ResultCode,
                    ResultMessage = e.Message
                });
                context.ExceptionHandled = true;
            }
        }
    }
}
