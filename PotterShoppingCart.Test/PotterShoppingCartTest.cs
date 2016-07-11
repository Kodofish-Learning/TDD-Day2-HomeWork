using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace PotterShoppingCart.Test
{
    /// <summary>
    /// PotterShoppingCartTest 的摘要描述
    /// </summary>
    [TestClass]
    public class PotterShoppingCartTest
    {
        public PotterShoppingCartTest()
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

        #endregion 其他測試屬性

        [TestMethod]
        public void Scenario_第一集買了一本_其他都沒買_價格應為100X1_合計100元()
        {
            //arrange
            List<Book> books = new List<Book> {
                new Book { Name="哈利波特1", Price=100 }
            };

            PotterShoppingCart target = new PotterShoppingCart();

            target.AddShoppingItem(books);

            //act
            var actual = target.getTotalPrice();

            //assert
            var expected = 100;
            Assert.AreEqual(expected, actual);
        }
    }
}