using FubuMVC.Coffee;
using FubuMVC.Core;
using FubuMVC.Less;
using FubuMVC.Sass;
using FubuMVC.Spark;
using HelloWorld.Home;

namespace HelloWorld
{
    public class ConfigureFubuMVC : FubuRegistry
    {
        public ConfigureFubuMVC()
        {
            IncludeDiagnostics(true);

            Applies
                .ToThisAssembly();

            Actions
                .IncludeClassesSuffixedWithController();

            Routes
                .HomeIs<HomeIn>()
                .IgnoreControllerNamesEntirely()
                .IgnoreControllerFolderName()
                .RootAtAssemblyNamespace();

            Import<LessExtension>();
            Import<SassExtension>();
            Import<CoffeeExtension>();

            Assets.CombineAllUniqueAssetRequests();

            this.UseSpark();
            Views.TryToAttachWithDefaultConventions();
        }
    }
}