using System;
using WorkItemDomain;

namespace WorkItemSimple
{
	public class WorkItem : IEntity
	{
		#region Static Methods & Properties
		private static IUnitOfWork unitOfWork;

		internal static void Init(IUnitOfWork work)
		{
			unitOfWork = work;
		}

		internal static WorkItem Create()
		{
			var wi = new WorkItem();
			wi.Id = -1;
			wi.State = "Proposed";
			unitOfWork.Entities.Add(wi);
			return wi;
		}
		internal static WorkItem FindById(int id)
		{
			return (WorkItem)unitOfWork.Entities.FindById(id);
		}
		#endregion

		#region Instance Methods & Properties
		public int Id { get; set; }
		public string State { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }

		public void Print()
		{
			Console.WriteLine("   Id:	{0}", this.Id);
			Console.WriteLine("State:	{0}", this.State);
			Console.WriteLine("Title:	{0}", this.Title);
			Console.WriteLine(" Desc:	{0}", this.Description);
		}

		public void Open()
		{
			switch (this.State)
			{
				case "Proposed":
					this.State = "Active";
					break;
				case "Active":
					Console.WriteLine("Work Item is already active.");
					break;
				case "Resolved":
					Console.WriteLine("Work Item is already resolved.");
					break;
				case "Closed":
					Console.WriteLine("Work Item is closed and cannot be modified.");
					break;
			}
		}

		public void Delete()
		{
			switch (this.State)
			{
				case "Proposed":
					unitOfWork.Entities.Remove(this);
					break;
				case "Active":
					Console.WriteLine("Work Item is already active. Cannot Delete.");
					break;
				case "Resolved":
					Console.WriteLine("Work Item is already resolved. Cannot Delete.");
					break;
				case "Closed":
					unitOfWork.Entities.Remove(this);
					break;
			}
		}

		public void Edit(string title, string description)
		{
			switch (this.State)
			{
				case "Proposed":
					this.Title = title;
					this.Description = description;
					break;
				case "Active":
					this.Title = title;
					this.Description = description;
					break;
				case "Resolved":
					Console.WriteLine("Work Item is already resolved and cannot be edited in this state.");
					break;
				case "Closed":
					Console.WriteLine("Work Item is closed and cannot be modified.");
					break;
			}
		}

		public void Resolve()
		{
			switch (this.State)
			{
				case "Proposed":
					Console.WriteLine("Work Item is in a proposed state and cannot be directly resolved.");
					break;
				case "Active":
					this.State = "Resolved";
					break;
				case "Resolved":
					Console.WriteLine("Work Item is already resolved.");
					break;
				case "Closed":
					Console.WriteLine("Work Item is closed and cannot be modified.");
					break;
			}
		}

		public void Verify()
		{
			switch (this.State)
			{
				case "Proposed":
					Console.WriteLine("Work Item is in a proposed state and cannot be directly closed.");
					break;
				case "Active":
					Console.WriteLine("Work Item cannot be closed without being resolved first.");
					break;
				case "Resolved":
					this.State = "Closed";
					break;
				case "Closed":
					Console.WriteLine("Work Item is closed and cannot be modified.");
					break;
			}
		}
		#endregion
	}
}