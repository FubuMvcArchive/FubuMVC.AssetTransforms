using FubuMVC.Core;
using FubuMVC.Core.Assets.Content;
using FubuMVC.Core.Registration;
using dotless.Core;

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
            s.SetServiceIfNone<ILessEngine>(new LessEngine());
            s.SetServiceIfNone<ILessCompiler, LessCompiler>();
            s.AddService<ITransformerPolicy, LessTransformerPolicy>();
        }
    }
}
