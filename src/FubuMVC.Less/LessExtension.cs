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
            registry.Services<LessServices>();
            MimeType.Css.AddExtension(LESS_EXTENSION);
        }

    }

    public class LessServices : ServiceRegistry
    {
        public LessServices()
        {
            SetServiceIfNone<ILogger, ExceptionLogger>();
            SetServiceIfNone<Parser, OptimizedParser>();
            SetServiceIfNone<IStylizer, PlainStylizer>();
            SetServiceIfNone<IImporter, DefaultImporter>();
            SetServiceIfNone<IFileReader, FileReader>();
            SetServiceIfNone<ILessEngine, DefaultEngine>();
            SetServiceIfNone<IPathResolver, AssetPathResolver>();
            SetServiceIfNone<ILessCompiler, LessCompiler>();
            AddService<ITransformerPolicy, LessTransformerPolicy>();
        }
    }
}
