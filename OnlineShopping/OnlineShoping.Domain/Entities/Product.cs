using OnlineShoping.Domain.Common;
using OnlineShoping.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoping.Domain.Entities
{
    public class Product : AuditableEntity<Guid>, IAggregateRoot
    {
        

        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public string PictureUri { get; private set; }
        public ProductType ProductType { get; private set; }
        public Guid ProductTypeId { get; private set; }
        public ProductBrand ProductBrand { get; private set; }
        public Guid ProductBrandId { get; private set; }

        public Product(string name,
            string description,
            decimal price,
            string pictureUri,
            ProductType productType,
            ProductBrand productBrand
            )
        {
            Name = name;
            Description = description;
            Price = price;
            PictureUri = pictureUri;
            ProductType = productType;
            ProductTypeId = productType.Id;
            ProductBrand = productBrand;
            ProductBrandId = productBrand.Id;
        }

        public void UpdateDetails(string name, string description, decimal price)
        {
            Guard.ForNullOrEmpty(name, nameof(name));
            Guard.ForNullOrEmpty(description, nameof(description));
            Guard.ForLessEqualZero(price, nameof(price));

            Name = name;
            Description = description;
            Price = price;
        }

        public void UpdateBrand(ProductBrand productBrand)
        {
            ProductBrand = productBrand;
            ProductBrandId = productBrand.Id;
        }

        public void UpdateType(ProductType productType)
        {
            ProductType = productType;
            ProductTypeId = productType.Id;
        }
    }
}
