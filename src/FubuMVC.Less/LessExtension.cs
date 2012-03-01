using System.Web;
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
    		s.SetServiceIfNone<ILessEngine>(new LessEngine(new Parser(new PlainStylizer(), new Importer(new FileReader(new AssetPathResolver())))));
            s.SetServiceIfNone<ILessCompiler, LessCompiler>();
            s.AddService<ITransformerPolicy, LessTransformerPolicy>();
        }
		internal class AssetPathResolver : IPathResolver {
			public string GetFullPath(string path) {
				return HttpContext.Current.Server.MapPath(path).Replace(@"\_content\", @"\Content\");
			}
		}
    }
}

