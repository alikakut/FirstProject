using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccsess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccsess.Concrete.InMemory
{
    public class InMemoryProductDal:IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product> {
               new Product{ProductId=1,CategoryId=1,ProductName="bardak",UnitPrice=15},
               new Product{ProductId=2,CategoryId = 2, ProductName = "kamera", UnitPrice = 500},
               new Product{ProductId=3,CategoryId = 3, ProductName = "fare", UnitPrice = 1500},
               new Product{ProductId=4,CategoryId = 4, ProductName = "telefon", UnitPrice = 150},
               new Product{ProductId=5,CategoryId = 5, ProductName = "klavye", UnitPrice = 85}
            };
        }

        public void add(Product entity)
        {
            throw new NotImplementedException();
        }

        public void delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> Getall(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<ProductDetailDto> GetProductDetailDtos()
        {
            throw new NotImplementedException();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
