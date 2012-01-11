using FubuMVC.Core;
using FubuMVC.Spark;

namespace HelloWorld
{
    public class ConfigureFubuMVC : FubuRegistry
    {
        public ConfigureFubuMVC()
        {
            IncludeDiagnostics(true);

            Actions.IncludeClassesSuffixedWithController();

            Routes
                .IgnoreControllerNamesEntirely()
                .IgnoreMethodSuffix("Html")
                .RootAtAssemblyNamespace();

            this.UseSpark();
            Views.TryToAttachWithDefaultConventions();
        }
    }
}