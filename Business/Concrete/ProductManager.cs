using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.CCS;
using Business.Constans;
using Business.ValidationRules.FluentVlaidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccsess.Abstract;
using DataAccsess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using Microsoft.IdentityModel.Tokens;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;

        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService=categoryService;
        }

        public ProductManager(EfCategoryDal efCategoryDal)
        {
            throw new NotImplementedException();
        }
         
       [ValidationAspect(typeof(ProductValidator))]
        public IResult add(Product product)
        { 
            IResult result = BusinessRules.Run(CheckIfProductNameExists(product.ProductName),CheckIfProductCountOfCategoryCorrect(product.CategoryId),
                CheckIfCategoryLimitexceded());
            if (result != null)
            {
                return result;
            }
            _productDal.add(product);
            return new SuccessResult(Messages.ProductAdded);

        }
       
        public IDataResult<List<Product>> Getall()
        {

            if (DateTime.Now.Hour == 12)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new DataResults<List<Product>>(_productDal.Getall(), true, "ürünler listelendi.");


        }

        public List<Product> GetallByCategoryId(int id)
        {
            return _productDal.Getall(p => p.CategoryId == id);
        }

        public Product GetById(int ProductId)
        {
            return _productDal.Get(p => p.ProductId == ProductId);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.Getall(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }


        public List<ProductDetailDto> GetProductDetailDtos()
        {
            return _productDal.GetProductDetails();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productDal.GetProductDetails();
        }
        //
        public IResult update(Product product)
        {
            throw new NotImplementedException();
        }

        IDataResult<List<Product>> IProductService.GetallByCategoryId(int id)
        {
            throw new NotImplementedException();
        }

        IDataResult<Product> IProductService.GetById(int ProductId)
        {
            throw new NotImplementedException();
        }

        IDataResult<List<Product>> IProductService.GetByUnitPrice(decimal min, decimal max)
        {
            throw new NotImplementedException();
        }

        IDataResult<List<ProductDetailDto>> IProductService.GetProductDetails()
        {
            throw new NotImplementedException();
        }

        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _productDal.Getall(p => p.CategoryId == categoryId).Count;
            if (result >= 15)
            {
                return new ErrorResult(Messages.productCountOfCategoryError);
            }
            return new SuccessResult();
        }
        private IResult CheckIfProductNameExists(string productname)
        {
            var result = _productDal.Getall(p => p.ProductName == productname).Any();
            if (result==true)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();
        }
        private Result CheckIfCategoryLimitexceded()
        {
            var result = _categoryService.Getall();
            if (result.Data.Count>15)
            {
                return new ErrorResult(Messages.CategoryLimitexceded);
            }
            return new SuccessResult();
        }

    }
}
