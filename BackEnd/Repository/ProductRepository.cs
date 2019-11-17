using BackEnd.Data;
using BackEnd.Model;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace BackEnd.Repository
{
    public class ProductRepository
    {
        private readonly DataContext dataContext;

        public ProductRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public IEnumerable<Product> GetQuery()
        {
            return dataContext.Products;
        }
        public Product GetById(int id)
        {
            return dataContext.Products.FirstOrDefault(x => x.Id == id);
        }

        public Product AddProduct(Product product)
        {
            dataContext.Add(product);
            dataContext.SaveChanges();
            return product;
        }

        public Product UpdateProduct(Product product, Product productDB)
        {
            productDB.Name = product.Name;
            productDB.Price = product.Price;
            productDB.ProductType = product.ProductType;
            productDB.Describe = product.Describe;
            productDB.Image = product.Image;
            dataContext.SaveChanges();
            return productDB;
        }

        public void DeleteProduct(Product productById)
        {
            dataContext.Remove(productById);
            dataContext.SaveChanges();
        }
    }
}
