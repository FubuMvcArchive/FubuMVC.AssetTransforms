using System.Collections.Generic;
using System.Linq;
using FubuMVC.Coffee;
using FubuMVC.Core;
using FubuMVC.Core.Assets.Combination;
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

            temporary();

            this.UseSpark();
            Views.TryToAttachWithDefaultConventions();
        }



        private void temporary()
        {
            // remove again when fix is applied for built-in
            Services(s => s.SetServiceIfNone<ICombinationDeterminationService, TemporaryCombinationService>());
        }
    }

    public class TemporaryCombinationService : CombinationDeterminationService
    {
        public TemporaryCombinationService(IAssetCombinationCache combinations)
            : base(combinations, new List<ICombinationPolicy> { new CombineAllScriptFiles(), new CombineAllStylesheets() }) {}

        public override void TryToReplaceWithCombinations(AssetTagPlan plan)
        {
            var mimeTypePolicies = policies.Where(x => x.MimeType == plan.MimeType);
            mimeTypePolicies.Each(p => ExecutePolicy(plan, p));
            base.TryToReplaceWithCombinations(plan);
        }
    }
}