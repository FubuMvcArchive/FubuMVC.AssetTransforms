using Bottles;
using FubuMVC.Core;
using FubuMVC.StructureMap;
using StructureMap;

[assembly: WebActivator.PreApplicationStartMethod(typeof(HelloWorld.App_Start.AppStartFubuMVC), "Start", callAfterGlobalAppStart: true)]

namespace HelloWorld.App_Start
{
    public static class AppStartFubuMVC
    {
        public static void Start()
        {
            FubuApplication.For<ConfigureFubuMVC>()
                .StructureMap(new Container())
                .Bootstrap();

			PackageRegistry.AssertNoFailures();
        }
    }
}