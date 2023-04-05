using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Concrete;
using Core.Utilities.Results;
using DataAccsess.Concrete.EntityFramework;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
           categorytest();
            //producttest();
        }

        private static void categorytest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.Getall().Data)
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void producttest()
        {
            ProductManager productmanager = new ProductManager(new EfProductDal(),new CategoryManager(new EfCategoryDal()));

               foreach (var product in productmanager.GetProductDetails())
               {
                Console.WriteLine(product.ProducName + "/" + product.CategoryName);

               }
        }
    }
}
