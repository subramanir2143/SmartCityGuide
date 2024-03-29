﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AIeSCT.Web.Startup))]
namespace AIeSCT.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            ConfigureAuth(app);
        }
    }
}
