using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OSLibrary.Sevices;

namespace OSLibraryTests1.Sevices
{
    [TestClass]
    public class OrdersServiceTest
    {
        [TestMethod]
        public void OrdersService_CreateOrder()
        {
            OrdersService service = new OrdersService();
            var str = service.CreateOrder("Osborn","信用卡","宅配",60);
            Assert.IsTrue(str == "完成訂單");
        }
    }
}
