using OSLibrary.ADO.NET.Repositories;
using OSLibrary.Containers;
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
        public IEnumerable<StockDetail> GetAll()
        {
            return RepositoryContainer.GetInstance<StockRepository>().GetAllOfBackStage().OrderBy(x=>x.Product_ID).ThenBy(x=>x.Color);
        }
        public IEnumerable<StockDetail> GetProduct_ID(int Product_ID)
        {
            return RepositoryContainer.GetInstance<StockRepository>().GetByProductIDOfBackStage(Product_ID).OrderBy(x=>x.Color);
        }

        public void UpdateStock(Stock stock)
        {
            RepositoryContainer.GetInstance<StockRepository>().Update(stock);
        }
        public bool CreateStock(CreateStock stock)
        {
            try
            {
                RepositoryContainer.GetInstance<StockRepository>().Create(new Stock {
                    Product_ID = stock.Product_ID,
                    Color = stock.Color,
                    Size = stock.Size,
                    Quantity = 0
                });
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public StockDetail GetStock(Stock stock)
        {
            return RepositoryContainer.GetInstance<StockRepository>().GetStock(stock.Product_ID, stock.Size, stock.Color);
        }
        public bool PurchaseStock(int Product_ID, string Size, string Color, int Quantity)
        {
            var repository = RepositoryContainer.GetInstance<StockRepository>();
            int nowQuantity = repository.GetQuantityByPK(Product_ID, Size, Color);
            try
            {
                repository.Update(new Stock
                {
                    Product_ID = Product_ID,
                    Size = Size,
                    Color = Color,
                    Quantity = nowQuantity + Quantity
                });
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
