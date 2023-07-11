using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace Hope.BackendServices.API.Areas.ConceptArt
{
    public class StatusAuthorization : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Get the statusId from the request body
            int statusId;
            
            if (context.ActionArguments.TryGetValue("statusId", out object statusIdValue))
            {
                if (statusIdValue is int)
                {
                    statusId = (int)statusIdValue;
                    
                    // Perform any additional logic with the statusId value
                    // ...

                    return; // Continue with the action execution
                }
            }

            // Invalid statusId value or missing from the request
            context.Result = new BadRequestObjectResult("Invalid statusId");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Perform any post-action processing if needed
        }
    }

}