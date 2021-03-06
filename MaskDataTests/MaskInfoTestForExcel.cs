﻿using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MaskData;

namespace MaskDataTests
{
    /// <summary>
    /// MaskInfoTestForExcel 的摘要描述
    /// </summary>
    [TestClass]
    public class MaskInfoTestForExcel
    {
        public MaskInfoTestForExcel()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///取得或設定提供目前測試回合
        ///相關資訊與功能的測試內容。
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

        #region 其他測試屬性
        //
        // 您可以使用下列其他屬性撰寫測試: 
        //
        // 執行該類別中第一項測試前，使用 ClassInitialize 執行程式碼
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // 在類別中的所有測試執行後，使用 ClassCleanup 執行程式碼
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // 在執行每一項測試之前，先使用 TestInitialize 執行程式碼 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // 在執行每一項測試之後，使用 TestCleanup 執行程式碼
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [DeploymentItem("MaskDataTests\\MaskDataTestExcel.xls"),
            DataSource("System.Data.Odbc","Dsn=Excel Files;dbq=.\\MaskDataTestExcel.xls;driverid=790;maxbuffersize=2048;pagetimeout=5","Sheet1$",DataAccessMethod.Sequential),
            TestMethod()]
        public void 遮罩Email地址透過EXCEL提供測試資料()
        {
            //arrange
            MaskInfo target = new MaskInfo('x');
            string inVal = TestContext.DataRow[0].ToString();
            string expected = TestContext.DataRow[1].ToString();
            string actual;
            //act
            target.getMaskValue(inVal, MaskType.email);
            actual = target.Result;
            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
