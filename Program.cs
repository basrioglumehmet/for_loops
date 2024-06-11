using for_loops.DataAccess.Abstract;
using for_loops.DataAccess.Concrete.InMemoryDb;
using for_loops.Entities;
using System;
using System.Collections.Generic;

namespace for_loops
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IProductDal productDal = new InMemoryProductDal();
            productDal.CreateProduct(entity: new Product { Name = "Product 1", Price = 10.99m, Campaign = true });
            productDal.CreateProduct(entity: new Product { Name = "Product 2", Price = 10.99m, Campaign = true });
            productDal.CreateProduct(entity: new Product { Name = "Product 3", Price = 10.99m, Campaign = true });
            IEnumerable<Product> products = productDal.GetAllProducts();

            foreach (var item in products)
            {
                Console.WriteLine(item);
            }

        }
    }
}