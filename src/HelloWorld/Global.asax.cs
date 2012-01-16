using System;
using System.Web;
using Bottles;
using FubuMVC.Core;
using FubuMVC.StructureMap;
using StructureMap;

namespace HelloWorld
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            FubuApplication.For<ConfigureFubuMVC>()
                .StructureMap(new Container())
                .Bootstrap();

            PackageRegistry.AssertNoFailures();
        }
    }
}