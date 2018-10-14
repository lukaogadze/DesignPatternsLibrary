using WorkItemAdvanced;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WorkItemDomain;

namespace WorkItemAdvanced.Tests
{
    
    
    /// <summary>
    ///This is a test class for WorkItemTest and is intended
    ///to contain all WorkItemTest Unit Tests
    ///</summary>
	[TestClass()]
	public class WorkItemTest
	{

		/// <summary>
		///A test for Create
		///</summary>
		[TestMethod()]
		public void CreateTest()
		{
			WorkItem.Init(new XmlUnitOfWork("test.xml"));
			var actual = WorkItem.Create();
			Assert.AreEqual("Proposed", actual.State);
			Assert.AreNotEqual(-1, actual.Id );
		}

		/// <summary>
		///A test for FindById
		///</summary>
		[TestMethod()]
		public void FindByIdTest()
		{
			WorkItem.Init(new XmlUnitOfWork("test.xml"));
			var expected = WorkItem.Create();
			var actual = WorkItem.FindById(expected.Id);
			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		///A test for State
		///</summary>
		[TestMethod()]
		public void StateTest()
		{
			WorkItem.Init(new XmlUnitOfWork("test.xml"));
			var wi = WorkItem.Create();
			wi.State = "Active";
			Assert.AreEqual("Active", wi.State);
		}
	}
}
