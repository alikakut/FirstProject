using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccsess.EntityFramework;
using DataAccsess.Abstract;
using Entities.Concrete;

namespace DataAccsess.Concrete.EntityFramework
{
    public class EfOrderDal:EfEntityRepositoryBase<Order,NortWindContext>,IOrderdal
    {
    }
}
