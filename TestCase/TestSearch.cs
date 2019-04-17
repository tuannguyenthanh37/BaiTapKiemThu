using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PMQLSanCauLong;
using System.IO;
using System.Data;
using System.Xml;
using System.Drawing;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data.Sql;
using System.Data.OleDb;

namespace TestCase
{
    /// <summary>
    /// Summary description for TestSearch
    /// </summary>
    [TestClass]
    public class TestSearch
    {
        public TestSearch()
        {
            //
            // TODO: Add constructor logic here
            //
        }

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
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestMethod1()
        {
            //
            // TODO: Add test logic here
            //
        }
        [TestMethod]
        public void TestSearchPhone()
        {
            Connection conn = new Connection();
            DataTable dulieu = conn.ExecuteData("select * from khachhang where sdt like '%" + "090" + "%'");
            Assert.IsTrue(dulieu.Rows.Count > 0);
        }
    }
}
