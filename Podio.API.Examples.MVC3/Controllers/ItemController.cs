﻿using Podio.API.Model;
using Podio.API.Services;
using Podio.API.Utils.ItemFields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Podio.API.Examples.MVC3.Controllers
{
    public class ItemController : Controller
    {
        public Client Client { get; set; }
        public Podio.API.Model.Application Application { get; set; }

        //
        // GET: /Item/Create
        [LoadApp]
        public ActionResult Create()
        {
            return View(this.Application);
        }

        //
        // POST: /Item/Create

        [HttpPost, LoadApp]
        public ActionResult Create(FormCollection collection)
        {
            var item = new Item();
            foreach (var appField in Application.Fields)
            {
                var rawValue = collection[appField.ExternalId];
                if(!String.IsNullOrEmpty(rawValue)) {
                    switch (appField.Type)
                    {
                        case "text":
                            var textField = item.Field<TextItemField>(appField.ExternalId);
                            textField.ExternalId = appField.ExternalId;
                            textField.Value = rawValue;
                            item.Fields.Add(textField);
                            break;
                        case "app":
                            var appRefField = item.Field<AppItemField>(appField.ExternalId);
                            appRefField.ExternalId = appField.ExternalId;
                            appRefField.ItemIds = rawValue.Split(',').Select(id => int.Parse(id));
                            item.Fields.Add(appRefField);
                            break;
                        case "contact":
                            var contactField = item.Field<ContactItemField>(appField.ExternalId);
                            contactField.ExternalId = appField.ExternalId;
                            contactField.ContactIds = rawValue.Split(',').Select(id => int.Parse(id));
                            item.Fields.Add(contactField);
                            break;
                    }
                }
            }

            this.Client.ItemService.AddNewItem((int)this.Application.AppId, item);
            return RedirectToRoute(new { controller = "Samples", action = "Index" });
        }

        private class LoadAppAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                if (!Podio.API.Examples.MVC3.Application.CurrentConnectionDetails.IsReadyToRubmble)
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { action = "Index", controller = "Authorization" }));
                }

                var client = Podio.API.Examples.MVC3.Application.CurrentConnectionDetails.GetClient();
                Podio.API.Model.Application app = client.ApplicationService.GetApp(Int32.Parse(filterContext.HttpContext.Request.QueryString["app_id"]));
                ((ItemController)filterContext.Controller).Client = client;
                ((ItemController)filterContext.Controller).Application = app;
            }
        }

    }
}