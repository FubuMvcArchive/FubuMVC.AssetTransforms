using System;
using SassAndCoffee.Core.Compilers;

namespace FubuMVC.Sass
{
    public interface ISassCompiler
    {
        string Compile(string content);
    }

    public class SassCompiler : ISassCompiler
    {
        public string Compile(string content)
        {
            /* Look closer at that goofy:             
             *  public void Init(ICompilerHost host)
             */

            //var compiler = new SassFileCompiler();
            //return compiler.ProcessFileContent(content);

            throw new NotImplementedException();
        }
    }
}