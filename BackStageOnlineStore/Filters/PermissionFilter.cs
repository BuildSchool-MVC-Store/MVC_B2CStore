using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BackStageOnlineStore.Filters
{
    public class PermissionFilter : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            if(filterContext.Result is HttpUnauthorizedResult)
            {
                CheckPermission(filterContext);
                return;
            }
        }

        private void CheckPermission(AuthorizationContext filterContext)
        {
            object areaName = null;

            if(filterContext.RouteData.DataTokens.TryGetValue("area", out areaName) && (areaName as string) == "BackStage")
            {
                filterContext.Result = new RedirectToRouteResult("index",
                    new RouteValueDictionary
                    {
                        { "controller", "Login" },
                        { "action", "Login" },
                        { "id", UrlParameter.Optional }
                    });
            }
            else
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
    }
}