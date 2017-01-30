using System;
using System.Web.Mvc;

namespace MvcPL.Infrastructure.Filters
{
    public class CustomFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext exceptionContext)
        {
            if (!exceptionContext.ExceptionHandled && (exceptionContext.Exception is ArgumentNullException || exceptionContext.Exception is NullReferenceException))
            {
                exceptionContext.Result = new RedirectResult("localhost/errors/error");
                exceptionContext.ExceptionHandled = true;               
            }
        }
    }
}