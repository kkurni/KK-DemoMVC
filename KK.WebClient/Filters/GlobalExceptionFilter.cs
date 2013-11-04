using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web;
using System.Web.Http.Filters;
using Elmah;

namespace KK.WebClient.Filters
{
    public class GlobalExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            var exceptionMessage = (actionExecutedContext.Exception != null)
                ? actionExecutedContext.Exception.Message
                : "Unknown Exception";

            ErrorSignal.FromCurrentContext().Raise(new Elmah.ApplicationException(exceptionMessage));
        }
    }
}