using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistentRowState
{
    public class Data
    {
        public static List<Product> GetDataList(int itemsCount)
        {
            List<Product> list = new List<Product>();
            for (int i = 0; i < itemsCount; i++)
                list.Add(new Product() { Name = "Product" + i,Description="Description "+i,Price=Convert.ToDecimal(i*5+10)});
            return list;
        }
    }

    public class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
