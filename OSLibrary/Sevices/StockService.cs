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
                    Quantity = item.Quantity
                };
                stocks.Add(stock);
            }
            return stocks;
        }
    }
}
