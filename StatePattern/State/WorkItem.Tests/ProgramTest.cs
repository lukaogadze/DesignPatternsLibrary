using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WorkItemAdvanced;

namespace WorkItem.Tests
{
    
    
    /// <summary>
    ///This is a test class for ProgramTest and is intended
    ///to contain all ProgramTest Unit Tests
    ///</summary>
	[TestClass()]
	public class ProgramTest
	{


		private TestContext testContextInstance;

		/// <summary>
		///Gets or sets the test context which provides
		///information about and functionality for the current test run.
		///</summary>
		public TestContext TestContext
		{
			get
			{
				return testContextInstance;
			}
			set
			{
				testContextInstance = value;
			}
		}

		#region Additional test attributes
		// 
		//You can use the following additional attributes as you write your tests:
		//
		//Use ClassInitialize to run code before running the first test in the class
		//[ClassInitialize()]
		//public static void MyClassInitialize(TestContext testContext)
		//{
		//}
		//
		//Use ClassCleanup to run code after all tests in a class have run
		//[ClassCleanup()]
		//public static void MyClassCleanup()
		//{
		//}
		//
		//Use TestInitialize to run code before running each test
		//[TestInitialize()]
		//public void MyTestInitialize()
		//{
		//}
		//
		//Use TestCleanup to run code after each test has run
		//[TestCleanup()]
		//public void MyTestCleanup()
		//{
		//}
		//
		#endregion


		/// <summary>
		///A test for Main
		///</summary>
		[TestMethod()]
		[DeploymentItem("State.exe")]
		public void Create()
		{
			Program_Accessor.Main("create -1 test1 desc1".Split());
			Program_Accessor.Main("create -1 test2 desc2".Split());
			Program_Accessor.Main("edit    1 test1edit test2desc".Split());
			Program_Accessor.Main("create -1 test desc".Split());
			Program_Accessor.Main("create -1 test desc".Split());
			Program_Accessor.Main("create -1 test desc".Split());
			Program_Accessor.Main("create -1 test desc".Split());
		}
	}
}
