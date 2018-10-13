using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Observer
{
	class Program
	{
		static void Main(string[] args)
		{
			switch (args[0].ToLower())
			{
				case "me":
					MotivatingExample.Program.Main(args);
					break;
				case "traditional":
					Traditional.Program.Main(args);
					break;
				case "eventanddelegate":
					EventAndDelegate.Program.Main(args);
					break;
				case "iobserver":
					IObserver.Program.Main(args);
					break;
			}
		}
	}
}
