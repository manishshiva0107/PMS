using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PMS.AuthenticateService
{
    public class CustomAuthenticateAttribute: TypeFilterAttribute
    {
        public CustomAuthenticateAttribute():base(typeof(CustomAuthenticateAttribute))
        {
        }
    }
    public class ClaimRequirementFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var url = context.HttpContext.Request.GetDisplayUrl();
            
            if (context.HttpContext.Session.GetInt32("UserId") == null)
            {
                context.Result = new RedirectToActionResult("Login", "User", new
                {
                    returnUrl = url
                });
            }
            
        }
    }
}
