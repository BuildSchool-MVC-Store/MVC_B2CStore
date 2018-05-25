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
        public bool CreateShoppingCart(string _account, int Product_ID, int Quantity, string Size, string Color)
        {
            StockRepository sizeQuantityRepository = new StockRepository();
            ShoppingCartRepository shoppingCart = new ShoppingCartRepository();
            ProductsRepository products = new ProductsRepository();
            var stock = sizeQuantityRepository.GetByPK(Product_ID, Size, Color);
            if (stock.Quantity < Quantity)
            {
                return false;
            }
            var myCart = shoppingCart.GetByAccount(_account);
            var items = myCart.FirstOrDefault(x => (x.Product_ID == Product_ID) && (x.size == Size));
            if (items != null)
            {
                shoppingCart.Update(items.Shopping_Cart_ID, items.Quantity + Quantity);
            }
            else
            {
                var model = new Shopping_Cart()
                {
                    Account = _account,
                    Product_ID = Product_ID,
                    size = Size,
                    UnitPrice = products.GetByProduct_ID(Product_ID).UnitPrice,
                    Quantity = (short)Quantity,
                    Color = Color
                };
                shoppingCart.Create(model);
            }
            return true;
        }

        public bool DeleteProduct(string _account, int Product_ID, int ShoppingCartID)
        {
            ShoppingCartRepository shoppingcart = new ShoppingCartRepository();
            var myCart = shoppingcart.GetByAccount(_account);
            try
            {
                shoppingcart.Delete(ShoppingCartID);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
