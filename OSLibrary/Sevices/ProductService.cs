
using OSLibrary.ADO.NET.Repositories;
using OSLibrary.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSLibrary.Sevices
{
    public class ProductService
    {
        public IEnumerable<ProductModel> GetAllProducts()
        {
            ProductsRepository productsRepository = new ProductsRepository();
            ProductImageRepository imageRepository = new ProductImageRepository();
            var products = new List<ProductModel>();
            foreach (var item in productsRepository.GetAll())
            {
                var img = imageRepository.GetByProduct_ID(item.Product_ID).FirstOrDefault(x => x.Image_Only == "YES").Image;
                var product = new ProductModel
                {
                    Name = item.Product_Name,
                    CategoryName = item.CategoryName,
                    Gender = item.Gender,
                    ImageUrl = "Images/Products/"+ img,
                    Price = item.UnitPrice,
                    ProductID = item.Product_ID
                };
                products.Add(product);
            }
            return products;
        }
    }
}
