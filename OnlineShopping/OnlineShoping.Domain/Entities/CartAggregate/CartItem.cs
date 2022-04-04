using OnlineShoping.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoping.Domain.Entities.CartAggregate
{
    public class CartItem : AuditableEntity<Guid>
    {
        public decimal UnitPrice { get; private set; }
        public int Quantity { get; private set; }
        public Guid ProductId { get; private set; }
        public Cart Cart { get; private set; }
        public Guid CartId { get; private set; }


        private CartItem() : base(Guid.NewGuid())
        {

        }

        public static CartItem Create(Guid productId, decimal unitPrice, int quantity)
        {
            Guard.OutOfRange(quantity, 0, int.MaxValue, nameof(quantity));
            return new CartItem
            {
                ProductId = productId,
                UnitPrice = unitPrice,
                Quantity = quantity
            };
        }

        public void AddQuantity(int quantity)
        {
            Guard.OutOfRange(quantity, 0, int.MaxValue, nameof(quantity));
            Quantity += quantity;
        }


    }

}
