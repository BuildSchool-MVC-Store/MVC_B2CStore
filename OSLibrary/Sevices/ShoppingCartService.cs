using OSLibrary.ADO.NET.Repositories;
using OSLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSLibrary.Sevices
{
    public class ShoppingCartService
    {
        public bool CreateShoppingCart(string _account, int Product_ID, int Quantity, string Product_Size)
        {
            ProductSizeQuantityRepository sizeQuantityRepository = new ProductSizeQuantityRepository();
            ShoppingCartRepository shoppingCart = new ShoppingCartRepository();
            ProductsRepository products = new ProductsRepository();
            var stock = sizeQuantityRepository.GetByProduct_IDandProduct_Size(Product_ID, Product_Size);
            if(stock.Quantity<Quantity)
            {
                return false;
            }
            var myCart = shoppingCart.GetByAccount(_account);
            var items = myCart.FirstOrDefault(x => (x.Product_ID == Product_ID) && (x.size == Product_Size));
            if(items != null)
            {
                shoppingCart.Update(items.Shopping_Cart_ID, items.Quantity + Quantity);
            }
            else
            {
                var model = new Shopping_Cart()
                {
                    Account = _account,
                    Product_ID = Product_ID,
                    size = Product_Size,
                    UnitPrice = products.GetByProduct_ID(Product_ID).UnitPrice,
                    Quantity = (short)Quantity
                };
                shoppingCart.Create(model);
            }
            return true;
        }
    }
}
