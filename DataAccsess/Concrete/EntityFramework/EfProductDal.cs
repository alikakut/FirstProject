using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccsess.EntityFramework;
using DataAccsess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccsess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NortWindContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetailDtos()
        {
            using (NortWindContext context = new NortWindContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId
                             select new ProductDetailDto { ProductId = p.ProductId,ProducName = p.ProductName,CategoryName = c.CategoryName};
                   return result.ToList();
            }
         
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            using (NortWindContext context = new NortWindContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId
                             select new ProductDetailDto { ProductId = p.ProductId, ProducName = p.ProductName, CategoryName = c.CategoryName };
                return result.ToList();
            }
        }
    }
}
