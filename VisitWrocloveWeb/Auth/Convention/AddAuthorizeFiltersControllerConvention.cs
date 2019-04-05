using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisitWrocloveWeb.Auth.Convention
{
    public class AddAuthorizeFiltersControllerConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            //edit ???
            if (controller.DisplayName.Contains("api"))
            {

            //}
            //if (controller.ControllerName.Contains("Api"))
            //{
                controller.Filters.Add(new AuthorizeFilter("apipolicy"));
            }
            else
            {
                controller.Filters.Add(new AuthorizeFilter("defaultpolicy"));
            }
        }
    }
}
