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
            var str = service.CreateOrder("Osborn","貨到付款","7-11,到店取貨",60);
            Console.WriteLine(str);
            Assert.IsFalse(str == "完成訂單");
        }
    }
}
