﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using Newtonsoft.Json.Serialization;

namespace procesos_app
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            HttpConfiguration config = GlobalConfiguration.Configuration;
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver 
                = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;
        }
    }
}
