using for_loops.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace for_loops.DataAccess.Abstract
{
    public interface IProductDal
    {
        Product CreateProduct(Product entity);
        Product ReadProduct(Guid productId);
        Product UpdateProduct(Product entity);
        Boolean DeleteProduct(Guid productId);
        IEnumerable<Product> GetAllProducts();
    }
}