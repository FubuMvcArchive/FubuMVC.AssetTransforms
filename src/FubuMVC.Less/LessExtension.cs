using FubuMVC.Core;
using FubuMVC.Core.Assets.Content;
using FubuMVC.Core.Registration;
using FubuMVC.Core.Runtime;

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
            SetServiceIfNone<dotless.Core.Loggers.ILogger, ExceptionLogger>();
            SetServiceIfNone<dotless.Core.Parser.Parser, OptimizedParser>();
            SetServiceIfNone<dotless.Core.Stylizers.IStylizer, dotless.Core.Stylizers.PlainStylizer>();
            SetServiceIfNone<dotless.Core.Importers.IImporter, DefaultImporter>();
            SetServiceIfNone<dotless.Core.ILessEngine, DefaultEngine>();
            SetServiceIfNone<dotless.Core.Input.IFileReader, DotLessFileReaderShim>();

            SetServiceIfNone<IFileReader, LessFileTransformerFileReader>();
            SetServiceIfNone<IPathResolver, AssetPathResolver>();
            SetServiceIfNone<ILessCompiler, LessCompiler>();
            AddService<ITransformerPolicy, LessTransformerPolicy>();
        }
    }
}
