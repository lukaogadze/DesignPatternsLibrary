using System.Linq;
using WorkItemAdvanced;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using WorkItemDomain;
using System.IO;

namespace WorkItemAdvanced.Tests
{
    
    /// <summary>
    ///This is a test class for XmlUnitOfWorkTest and is intended
    ///to contain all XmlUnitOfWorkTest Unit Tests
    ///</summary>
	[TestClass()]
	public class XmlUnitOfWorkTest
	{
		private string fileName = "any sample file name.txt";

		[TestInitialize]
		public void Initialize()
		{
			File.Delete(fileName);
		}

		/// <summary>
		///A test for XmlUnitOfWork Constructor
		///</summary>
		[TestMethod()]
		public void XmlUnitOfWorkConstructorTest()
		{
			var target = new XmlUnitOfWork(fileName);
			Assert.IsNotNull(target);
		}

		/// <summary>
		///A test for Commit
		///</summary>
		[TestMethod()]
		public void CommitTest()
		{
			var target = new XmlUnitOfWork(fileName);
			target.Entities.Add(new WorkItem());
			target.Commit();

			var exists = File.Exists(fileName);
			Assert.IsTrue(exists, "File was not found.");
		}

		/// <summary>
		///A test for ReadXml
		///</summary>
		[TestMethod()]
		[DeploymentItem("WorkItemAdvanced.exe")]
		public void ReadXmlTest()
		{
			var uow = new XmlUnitOfWork(fileName);
			var x = new WorkItem {Description = "test", Id = 0, State = "test", Title = "test"};
			uow.Entities.Add(x);
			uow.Commit();

			var target = new XmlUnitOfWork_Accessor(fileName);
			Assert.AreEqual(1, target.ReadXml().Count());
		}

		/// <summary>
		///A test for Entities
		///</summary>
		[TestMethod()]
		public void EntitiesTest()
		{
			var uow = new XmlUnitOfWork(fileName);
			var x = new WorkItem { Description = "test", Id = 0, State = "test", Title = "test" };
			uow.Entities.Add(x);
			uow.Commit();
			
			uow = new XmlUnitOfWork(fileName);
			var actual = uow.Entities.FindById(1) as WorkItem; // 0 is just a placeholder
			Assert.AreEqual(x.Description, actual.Description);
		}
	}
}
