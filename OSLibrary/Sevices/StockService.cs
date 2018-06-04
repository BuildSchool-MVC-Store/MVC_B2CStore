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
    public class StockService
    {
        public StockModel GetProductIDByStock(int Product_ID, string Size, string Color)
        {
            var stockrepository = new StockRepository();
            var productrepository = new ProductsRepository();
            var model = stockrepository.GetByProductID(Product_ID, Size, Color);
            return new StockModel()
            {
                Product_ID = model.Product_ID,
                ProductName = productrepository.GetByProduct_ID(Product_ID).Product_Name,
                Size = model.Size,
                Color = model.Color,
                Quantity = model.Quantity
            };
        }
        public IEnumerable<StockModel> GetAllByStock()
        {
            StockRepository stockrepository = new StockRepository();
            var productrepository = new ProductsRepository();
            var stocks = new List<StockModel>();
            foreach (var item in stockrepository.GetAll())
            {
                var stock = new StockModel()
                {
                    Product_ID = item.Product_ID,
                    ProductName = productrepository.GetByProduct_ID(item.Product_ID).Product_Name,
                    Size = item.Size,
                    Color = item.Color,
                    Quantity = item.Quantity
                };
                stocks.Add(stock);
            }
            return stocks;
        }

        public bool UpdateStock(int Product_ID, string Color, string Size, int? Quantity)
        {
            var stock = new Stock()
            {
                Product_ID = Product_ID,
                Color = Color,
                Size = Size,
                Quantity = Quantity
            };
            var repository = new StockRepository();
            try
            {
                repository.Update(stock);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
