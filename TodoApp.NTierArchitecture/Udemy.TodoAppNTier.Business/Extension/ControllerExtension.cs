
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.TodoAppNTier.Common.ResponseObject;

namespace Udemy.TodoAppNTier.Business.Extension
{
    public static class ControllerExtension
    {
        public static IActionResult ResponseRediretToAction<T>(this Controller controller, IResponse<T> response, string actionName)
        {
            if(response.ResponseType == ResponseType.NotFound)
            {
                return controller.NotFound();
            }
            if(response.ResponseType == ResponseType.ValidationError)
            {
                foreach (var error in response.ValidationErrors)
                {
                    controller.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return controller.View(response.Data);
            }
            return controller.RedirectToAction();
        }

        public static IActionResult ResponseView<T>(this Controller controller, IResponse<T> response)
        {
            if (response.ResponseType == ResponseType.NotFound) ;
        }
    }
}
