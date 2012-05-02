using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dotless.Core.Importers;
using dotless.Core.Input;

namespace FubuMVC.Less {
	/// <summary>
	/// Making the container happy
	/// </summary>
	public class DefaultImporter : Importer {
		public DefaultImporter(IFileReader fileReader) : base(fileReader) {}
	}
}
