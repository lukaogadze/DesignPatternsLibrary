using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkItemDomain;

namespace WorkItemAdvanced.States
{
	class BaseState
	{
		public void Print(WorkItem wi)
		{
			Console.WriteLine("   Id:	{0}", wi.Id);
			Console.WriteLine("State:	{0}", wi.State);
			Console.WriteLine("Title:	{0}", wi.Title);
			Console.WriteLine(" Desc:	{0}", wi.Description);
		}
	}
}
