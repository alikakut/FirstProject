using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constans
{
    public static class Messages
    {
        public static string ProductAdded = "ürün eklendi.";
        public static string ProductNameInvalid ="Ürün ismi geçersiz";
        public static string MaintenanceTime = "sistem bakımda";
        internal static string productCountOfCategoryError = "Bir kategoride en fazla 10 ürün olabilir";
        internal static string ProductNameAlreadyExists="Bu isimde zaten başka bir ürün var";

        public static string CategoryLimitexceded = " katgori limiti aşıldığı için yeni ürün eklenemiyor";
        //public static string ProductsListed = "ürünler listelendi";
    }
}
