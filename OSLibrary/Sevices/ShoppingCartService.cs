using OSLibrary.ADO.NET.Repositories;
using OSLibrary.Models;
using OSLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSLibrary.Sevices
{
    public class ShoppingCartService
    {
        public IEnumerable<ShoppingCartDetail> GetAccountCart(string Account)
        {
            var model = new List<ShoppingCartDetail>();
            ShoppingCartRepository shoppingCartRepository = new ShoppingCartRepository();
            ProductsRepository productsRepository = new ProductsRepository();
            ProductImageRepository productImageRepository = new ProductImageRepository();

            foreach (var item in shoppingCartRepository.GetByAccount(Account))
            {
                var cart = new ShoppingCartDetail
                {
                    Account = Account,
                    Color = item.Color,
                    ProductID = item.Product_ID,
                    Name = productsRepository.GetByProduct_ID(item.Product_ID).Product_Name,
                    ShoppingCartID = item.Shopping_Cart_ID,
                    Quantity = item.Quantity,
                    RowPrice = item.UnitPrice * item.Quantity,
                    UnitPrice = item.UnitPrice,
                    Size = item.size,
                    imgurl = productImageRepository.GetByProduct_ID(item.Product_ID).FirstOrDefault(x=>x.Image_Only=="YES").Image
                };
                model.Add(cart);
            }
            return model;
        }
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
                    Color = Color,
                    
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
