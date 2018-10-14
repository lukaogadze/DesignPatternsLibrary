using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkItemDomain;

namespace WorkItemAdvanced.States
{
	class Active : BaseState, ICommands
	{
		private WorkItem owner;

		public Active(WorkItem owner)
		{
			this.owner = owner;
		}

		public bool Delete()
		{
			Console.WriteLine("Work Item is already active. Cannot Delete.");
			return false;
		}

		public void Edit(string title, string desc)
		{
			owner.Title = title;
			owner.Description = desc;
		}

		public void Print()
		{
			Print(owner);
		}

		public void SetState(string state)
		{
			switch (state)
			{
				case "active":
					Console.WriteLine("Work Item is already active.");
					break;
				case "proposed":
				case "resolved":
					owner.State = state;
					break;
				default:
					Console.WriteLine("Work Item is in an active state and cannot be set to {0}.", state);
					break;
			}
		}
	}
}
