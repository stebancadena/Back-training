using APM_Back.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;

namespace APM_Back.ActionFilters
{
    public class ValidateEntityExistsClass<T> : IActionFilter where T : Product
    {
        private readonly DataContext _dataContext;
        public ValidateEntityExistsClass(DataContext context)
        {
            _dataContext = context;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Guid id;

            if (context.ActionArguments.ContainsKey("id"))
            {
                id = (Guid)context.ActionArguments["id"];
            }
            else
            {
                context.Result = new BadRequestObjectResult("Bad id parameter");
                return;
            }

            var entity = _dataContext.Set<T>().SingleOrDefault(x => x.ProductId.Equals(id));
            if(entity == null)
            {
                context.Result = new NotFoundResult();
            }else
            {
                context.HttpContext.Items.Add("entity", entity);
            }
        }
    }
}
