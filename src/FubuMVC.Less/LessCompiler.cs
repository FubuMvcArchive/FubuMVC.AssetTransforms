using dotless.Core;

namespace FubuMVC.Less
{
    public interface ILessCompiler
    {
        string Compile(string less);
    }

    public class LessCompiler : ILessCompiler
    {
        private readonly ILessEngine _engine;
        public LessCompiler(ILessEngine engine)
        {
            _engine = engine;
        }

        public string Compile(string less)
        {
            return _engine.TransformToCss(less, null);
        }
    }
}