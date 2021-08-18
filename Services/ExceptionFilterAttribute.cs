using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ExceptionFilterAttribute : IAsyncExceptionFilter
    {
        private readonly ILogger<ExceptionFilterAttribute> _logger;

        public ExceptionFilterAttribute(
            ILogger<ExceptionFilterAttribute> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }


        public async Task OnExceptionAsync(ExceptionContext context)
        {
            context.ExceptionHandled = true;

            await Task.Run(() => _logger.LogError(context.Exception, context.Exception.Message, null));
            var result = new RedirectToRouteResult
                  (
                  new RouteValueDictionary(new
                  {
                      action = "Error",
                      controller = "Home"
                  }));

            context.Result = result;
            return;
        }
    }
}
