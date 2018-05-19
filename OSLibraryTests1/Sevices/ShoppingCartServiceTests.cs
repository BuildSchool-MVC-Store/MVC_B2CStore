using Microsoft.VisualStudio.TestTools.UnitTesting;
using OSLibrary.Sevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSLibrary.Sevices.Tests
{
    [TestClass()]
    public class ShoppingCartServiceTests
    {
        [TestMethod()]
        public void ShoppingCartServiceTests_CreateShoppingCart()
        {
            ShoppingCartService service = new ShoppingCartService();
            
            //Assert.IsTrue(service.CreateShoppingCart("Osborn",2,1,"M")==true);

            Assert.IsFalse(service.CreateShoppingCart("Osborn", 2, 10, "M"));
        }
    }
}