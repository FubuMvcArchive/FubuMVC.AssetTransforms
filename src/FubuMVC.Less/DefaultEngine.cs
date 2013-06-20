using dotless.Core;
using dotless.Core.Loggers;
using dotless.Core.Parser;

namespace FubuMVC.Less {
	/// <summary>
	/// Making the container happy
	/// </summary>
	public class DefaultEngine : LessEngine {
		public DefaultEngine(Parser parser, ILogger logger) : base(parser, logger, false, false) {}
	}
}
