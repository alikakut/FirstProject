using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccsess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccsess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    {
        List<ProductDetailDto> GetProductDetailDtos();
        List<ProductDetailDto> GetProductDetails();
    }
}
