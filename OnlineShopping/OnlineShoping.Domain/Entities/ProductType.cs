using OnlineShoping.Domain.Common;
using OnlineShoping.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoping.Domain.Entities
{
    public class ProductType : AuditableEntity<Guid>, IAggregateRoot
    {
        public string Type { get; private set; }

        public ProductType(string type)
        {
            Type = type;
        }
    }
}
