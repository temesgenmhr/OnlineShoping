using OnlineShoping.Domain.Common;
using OnlineShoping.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoping.Domain.Entities
{
    public class ProductBrand : AuditableEntity<Guid>, IAggregateRoot
    {
        public string Brand { get; private set; }

        public ProductBrand(string brand)
        {
            Brand = brand;
        }
    }
}
