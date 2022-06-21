using Microsoft.AspNetCore.Mvc.Filters;

namespace Trackr.ActionFilters
{
    public class ValidationFilterAttribute : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if(!context.ModelState.IsValid)
            {
                context.Result = new Microsoft.AspNetCore.Mvc.UnprocessableEntityObjectResult(context.ModelState);
            }
        }
    }
}
