using FubuMVC.Core;
using FubuMVC.Core.Assets.Content;
using FubuMVC.Core.Registration;
using FubuMVC.Core.Runtime;
using dotless.Core;
using dotless.Core.Importers;
using dotless.Core.Input;
using dotless.Core.Loggers;
using dotless.Core.Parser;
using dotless.Core.Stylizers;

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
			s.SetServiceIfNone<ILogger, ExceptionLogger>();
			s.SetServiceIfNone<Parser, OptimizedParser>();
			s.SetServiceIfNone<IStylizer, PlainStylizer>();
			s.SetServiceIfNone<IImporter, Importer>();
			s.SetServiceIfNone<IFileReader, FileReader>();
			s.SetServiceIfNone<ILessEngine, LessEngine>();
			s.SetServiceIfNone<IPathResolver, AssetPathResolver>();
            s.SetServiceIfNone<ILessCompiler, LessCompiler>();
            s.AddService<ITransformerPolicy, LessTransformerPolicy>();
        }
    }
}
