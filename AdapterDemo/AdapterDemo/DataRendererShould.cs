using System;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using AdapterDemo.Model;
using AdapterDemo.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdapterDemo
{
    [TestClass]
    public class DataRendererShould
    {
        [TestMethod]
        public void RenderOneRowGivenStubDataAdapter()
        {
            var myRenderer = new DataRenderer(new StubDbAdapter());

            var writer = new StringWriter();
            myRenderer.Render(writer);

            string result = writer.ToString();
            Console.Write(result);

            int lineCount = result.Count(c => c == '\n');
            Assert.AreEqual(3, lineCount);
        }

        [TestMethod]
        public void RenderTwoRowsGivenOleDbDataAdapter()
        {
            var adapter = new OleDbDataAdapter();
            adapter.SelectCommand = new OleDbCommand("SELECT * FROM Pattern");
            adapter.SelectCommand.Connection =
                new OleDbConnection(
                    @"Provider=Microsoft.SQLSERVER.CE.OLEDB.3.5;Data Source=C:\Users\loghadze\RiderProjects\DesignPatternsLibrary\AdapterDemo\AdapterDemo\Sample.sdf");
            var myRenderer = new DataRenderer(adapter);

            var writer = new StringWriter();
            myRenderer.Render(writer);

            string result = writer.ToString();
            Console.Write(result);

            int lineCount = result.Count(c => c == '\n');
            Assert.AreEqual(4, lineCount);
        }
    }
}