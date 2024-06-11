using for_loops.DataAccess.Abstract;
using for_loops.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace for_loops.DataAccess.Concrete.InMemoryDb
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> products;

        public InMemoryProductDal()
        {
            products = new List<Product>();
        }

        public Product CreateProduct(Product entity)
        {
            products.Add(entity);
            return entity;
        }

        public bool DeleteProduct(Guid productId)
        {
            //LINQ - Language Integrated Query
            //Lambda
            Product? product = products.SingleOrDefault(p => p.Equals(productId));
            if (product != null)
            {
                products.Remove(product);
                return true;
            }
            return false;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }

        public Product ReadProduct(Guid productId)
        {
            Product? product = products.SingleOrDefault(p => p.Equals(productId));
            if (product != null)
            {
                return product;
            }
            throw new Exception("Cannot find the product");
        }

        public Product UpdateProduct(Product entity)
        {
            Product? product = products.SingleOrDefault(p => p.Equals(entity.Id));
            if (product != null)
            {
                product.Price= entity.Price;
                product.PercentOfDiscount= entity.PercentOfDiscount;
                product.ModifiedDate= entity.ModifiedDate;
                product.Name= entity.Name;
                product.Campaign = entity.Campaign;
                return product;
            }
            throw new Exception("Cannot find the product");
        }

        public IEnumerator<Product> GetEnumerator()
        {
            return new ProductEnumerator(products);
        }
    }

    public class ProductEnumerator : IEnumerator<Product>
    {
        private readonly List<Product> products;
        private int currentIndex = -1;

        public ProductEnumerator(List<Product> products)
        {
            this.products = products;
        }

        public Product Current => products[currentIndex];

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            // Gerekiyorsa kaynakların temizlenmesi
        }

        public bool MoveNext()
        {
            currentIndex++;
            return currentIndex < products.Count;
        }

        public void Reset()
        {
            currentIndex = -1;
        }
    }

}

