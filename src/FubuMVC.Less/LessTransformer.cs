using System.Collections.Generic;
using FubuMVC.Core.Assets.Content;
using FubuMVC.Core.Assets.Files;
using System.Linq;
using dotless.Core.Input;

namespace FubuMVC.Less
{
    public class LessTransformer : ITransformer
    {
        private readonly ILessCompiler _compiler;
    	private readonly AssetPathResolver _resolver;

		public LessTransformer(ILessCompiler compiler, IPathResolver resolver) {
        	_compiler = compiler;
        	_resolver = (AssetPathResolver) resolver;
        }

    	public string Transform(string contents, IEnumerable<AssetFile> files)
        {
			if (files.Any())
				_resolver.CurrentFolder = files.First().ContentFolder();
			return _compiler.Compile(contents);
        }
    }
}