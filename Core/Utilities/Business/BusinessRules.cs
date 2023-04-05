using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] Logics)
        {
            foreach (var Logic in Logics)
            {
                if (!Logic.Success)
                {
                    return Logic;
                }
            }
            return null;
        }
    }
}
