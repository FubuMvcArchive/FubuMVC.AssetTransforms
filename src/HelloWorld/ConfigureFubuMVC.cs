using FubuMVC.Coffee;
using FubuMVC.Core;
using FubuMVC.Core.Assets;
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
            Actions
                .IncludeClassesSuffixedWithController();

            Import<SparkEngine>();

            Routes
                .HomeIs<HomeIn>()
                .IgnoreControllerNamesEntirely()
                .IgnoreControllerFolderName()
                .RootAtAssemblyNamespace();

            Import<LessExtension>();
            Import<SassExtension>();
            Import<CoffeeExtension>();

            this.Assets().CombineAllUniqueAssetRequests();
        }
    }
}