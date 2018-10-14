using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkItemDomain;

namespace WorkItemAdvanced.States
{
	class Closed : BaseState, ICommands
	{
		private WorkItem owner;

		public Closed(WorkItem owner)
		{
			this.owner = owner;
		}

		public bool Delete()
		{
			return true;
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
				case "closed":
					Console.WriteLine("Work Item is already closed.");
					break;
				case "resolved":
					owner.State = state;
					break;
				default:
					Console.WriteLine("Work Item is in a closed state and cannot be set to {0}.", state);
					break;
			}
		}
	}
}
