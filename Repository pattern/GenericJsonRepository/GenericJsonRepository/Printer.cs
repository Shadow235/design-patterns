using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericJsonRepository
{
	public class Printer
	{
		public string Name { get; set; } = string.Empty;

		public override int GetHashCode()
		{
			return Name.GetHashCode();
		}
	}
}
