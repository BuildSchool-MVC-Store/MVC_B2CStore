﻿
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
                    ImageUrl = "/Images/Products/" + img,
                    Price = item.UnitPrice,
                    ProductID = item.Product_ID
                };
                products.Add(product);
            }
            return products;
        }
        //public ProductDetail GetProductDetail(int ProdcutID)
        //{
        //    ProductImageRepository imageRepository = new ProductImageRepository();
        //    ProductsRepository productsRepository = new ProductsRepository();
        //    StockRepository stockRepository = new StockRepository();
        //    var products = productsRepository.GetByProduct_ID(ProdcutID);
        //    var allImage = imageRepository.GetByProduct_ID(ProdcutID);
        //    var Image = allImage.Select(x => "/Images/Products/" + x.Image).ToList();
        //    var stock = stockRepository.GetByProductID(ProdcutID);
        //    Dictionary<string, List<string>> ColorSize = new Dictionary<string, List<string>>();
        //    foreach (var color in stock.Select(x => x.Color).Distinct())
        //    {
        //        var _size = stock.Where(x => x.Color == color).Select(x => x.Size).ToList();
        //        ColorSize.Add(color, _size);
        //    };
        //    return new ProductDetail()
        //    {
        //        ID = products.Product_ID,
        //        Name = products.Product_Name,
        //        Comments = products.Comments,
        //        Price = products.UnitPrice,
        //        Image = Image,
        //        ColorSize = ColorSize,
        //        Color = stock.Select(x => x.Color).Distinct().ToList(),
        //        Size = stock.Select(x => x.Size).Distinct().ToList()
        //    };
        //}
        public IEnumerable<BackStageProductModel> BackStageGetAllProducts()
        {
            ProductsRepository productsRepository = new ProductsRepository();
            var products = new List<BackStageProductModel>();
            foreach (var item in productsRepository.GetAll())
            {
                var product = new BackStageProductModel
                {
                    Name = item.Product_Name,
                    CategoryName = item.CategoryName,
                    Gender = item.Gender,
                    Price = item.UnitPrice,
                    ProductID = item.Product_ID,
                    Online = item.Online
                };
                products.Add(product);
            }
            return products;
        }

        public ProductModel GetProductByProductID(int Product_ID)
        {
            var repository = new ProductsRepository();
            var model = repository.GetByProduct_ID(Product_ID);
            return new ProductModel()
            {
                ProductID = model.Product_ID,
                Name = model.Product_Name,
                CategoryName = model.CategoryName,
                Gender = model.Gender,
                Online = model.Online,
                Price = model.UnitPrice,
                Comments = model.Comments
            };
        }

        public bool UpdateProducts(int Product_ID, string ProductName, int Price, string CategoryName, string Gender, string Online, string Comments)
        {
            var productsrepository = new ProductsRepository();
            var Products = new Products()
            {
                Product_ID = Product_ID,
                Product_Name = ProductName,
                UnitPrice = Price,
                CategoryName = CategoryName,
                Gender = Gender,
                Online = Online,
                Comments = Comments
            };
            try
            {
                productsrepository.Update(Products);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteProducts(int Product_ID)
        {
            var repository = new ProductsRepository();
            try
            {
                repository.Delete(Product_ID);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
