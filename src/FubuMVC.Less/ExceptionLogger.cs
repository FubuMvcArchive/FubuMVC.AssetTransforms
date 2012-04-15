using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dotless.Core.Loggers;

namespace FubuMVC.Less {
	public class ExceptionLogger : Logger {
		public ExceptionLogger() : base(LogLevel.Error) {}
		protected override void Log(string message) {
			throw new ParserException(message);
		}
	}
}
