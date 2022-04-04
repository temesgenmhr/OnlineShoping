using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShoping.Domain.Entities.CartAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Persistence.Configurations.Carts
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            var navigation = builder.Metadata.FindNavigation(nameof(Cart.CartItems));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
             builder.HasMany(e => e.CartItems).WithOne(e => e.Cart);
        }
    }
}
