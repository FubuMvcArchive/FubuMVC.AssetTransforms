using FubuMVC.Core;
using FubuMVC.Core.Assets.Content;
using FubuMVC.Core.Registration;
using dotless.Core;
using dotless.Core.Importers;
using dotless.Core.Input;
using dotless.Core.Parser;
using dotless.Core.Stylizers;

namespace FubuMVC.Less
{
    public class LessExtension : IFubuRegistryExtension
    {
        public void Configure(FubuRegistry registry)
        {
            registry.Services(services);
        }

        private static void services(IServiceRegistry s)
        {
			s.SetServiceIfNone<ILessEngine, LessEngine>();
			s.SetServiceIfNone<IPathResolver, AssetPathResolver>();
            s.SetServiceIfNone<ILessCompiler, LessCompiler>();
            s.AddService<ITransformerPolicy, LessTransformerPolicy>();
        }
    }
}
