﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccsess;
using Entities.Concrete;

namespace DataAccsess.Abstract
{
    public interface IOrderdal:IEntityRepository<Order>
    {
    }
}
