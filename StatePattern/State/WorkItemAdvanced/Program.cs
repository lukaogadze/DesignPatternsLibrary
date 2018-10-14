using System;
using System.Linq;
using WorkItemDomain;

namespace WorkItemAdvanced
{
	internal class Program
	{
		private static IUnitOfWork unitOfWork;

		public static void Main(string[] args)
		{
			// Create Data Conneciton
			unitOfWork = new XmlUnitOfWork(@"./data.xml");
			WorkItem.Init(unitOfWork);

			// Parse the arguments
			string cmd, title = null, desc = null, state = null;
			int id;
			try
			{
				cmd = args[0].ToLower();
				id = int.Parse(args[1]);
				if (args.Count() > 2)
					title = args[2];
				if (args.Count() > 3)
					desc = args[3];
				if (args.Count() > 4)
					state = args[4];
			}
			catch (Exception)
			{
				PrintUsage();
				return;
			}

			var wi = WorkItem.FindById(id);

			// Execute Command
			try
			{
				switch (cmd)
				{
					case "create":
						wi = WorkItem.Create();
						wi.Edit(title, desc);
						wi.Print();
						break;
					case "delete":
						wi.Delete();
						break;
					case "edit":
						wi.Edit(title, desc);
						break;
					case "print":
						wi.Print();
						break;
					case "setstate":
						wi.SetState(state);
						break;
					default:
						PrintUsage();
						return;
				}

				// Commit the work
				unitOfWork.Commit();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Unable to perform operation. " + ex.Message);
				PrintUsage();
			}
		}

		private static void PrintUsage()
		{
			Console.WriteLine("Usage: state <command> <id> <title> <description> <state>");
			Console.WriteLine("Commands: create, delete, edit, print, setstate");
			Console.WriteLine("States: Proposed, Active, Resolved, Closed");
		}

	}
}