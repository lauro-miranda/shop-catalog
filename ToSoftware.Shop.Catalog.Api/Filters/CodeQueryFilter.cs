using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;

namespace ToSoftware.Shop.Catalog.Api.Filters
{
    public class CodeQueryFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var codes = context.HttpContext.Request.Path.ToString().Replace("/api/product/s/", "").Split(';');

            if (!codes.Any())
                context.Result = new BadRequestObjectResult("Códigos não informados.");

            context.ActionArguments["codes"] = codes.Select(c => Guid.Parse(c)).ToList();
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}