using FubuMVC.Core;
using FubuMVC.Core.Assets.Content;
using FubuMVC.Core.Registration;
using FubuMVC.Core.Runtime;
using dotless.Core;

namespace FubuMVC.Less
{
    public class LessExtension : IFubuRegistryExtension
    {
        public const string LESS_EXTENSION = ".less";

        public void Configure(FubuRegistry registry)
        {
            registry.Services(registerDefaultServices);
            MimeType.Css.AddExtension(LESS_EXTENSION);
        }

        private static void registerDefaultServices(IServiceRegistry s)
        {
            s.SetServiceIfNone<ILessEngine>(new LessEngine());
            s.SetServiceIfNone<ILessCompiler, LessCompiler>();
            s.AddService<ITransformerPolicy, LessTransformerPolicy>();
        }
    }
}
