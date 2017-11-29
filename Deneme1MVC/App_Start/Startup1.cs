﻿using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;

[assembly: OwinStartup(typeof(Deneme1MVC.App_Start.Startup1))]

namespace Deneme1MVC.App_Start
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            app.UseCookieAuthentication(new CookieAuthenticationOptions

            {

                AuthenticationType = "ApplicationCookie",

                LoginPath = new PathString("/Account/Login")

            });
        }
    }
}
