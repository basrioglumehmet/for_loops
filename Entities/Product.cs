using for_loops.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace for_loops.Entities
{
    public class Product : IEntity
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool Campaign { get; set; }
        public int PercentOfDiscount { get; set; }
        public DateTime CreatedDate { get; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;

        public override string ToString()
        {
            return $"Name:{Name},Price:{Price},Discount:{PercentOfDiscount},Created:{CreatedDate},Modified:{ModifiedDate}";
        }
    }
}