using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Cart.API.Filters {

    public class RequiredActionFilter : IActionFilter {

        public void OnActionExecuting(ActionExecutingContext context) {
            var paths = context.HttpContext.Request.Path.Value.Split('/');
            if(paths.Count() < 3 )
            {
                throw new InvalidOperationException("Customer Id not present");
            }
 
        }

        public void OnActionExecuted(ActionExecutedContext context) {

        }


    }
}
