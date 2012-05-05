using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dotless.Core.Importers;
using dotless.Core.Parser;
using dotless.Core.Stylizers;

namespace FubuMVC.Less {
	/// <summary>
	/// Making the container happy
	/// </summary>
	public class OptimizedParser : Parser {
		public OptimizedParser(IStylizer stylizer, IImporter importer) : base(stylizer, importer) {}
	}
}
