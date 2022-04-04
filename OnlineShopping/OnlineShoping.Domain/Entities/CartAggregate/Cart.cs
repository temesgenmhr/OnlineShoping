using OnlineShoping.Domain.Common;
using OnlineShoping.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoping.Domain.Entities.CartAggregate
{
    public class Cart : AuditableEntity<Guid>, IAggregateRoot
    {
        public string BuyerId { get; private set; }

        private readonly List<CartItem> _cartItems = new List<CartItem>();
        public IReadOnlyCollection<CartItem> CartItems => _cartItems.AsReadOnly();

        public int TotalItems => _cartItems.Sum(i => i.Quantity);

        private Cart() : base(Guid.NewGuid())
        {

        }

        public static Cart Create(string buyerId)
        {
            return new Cart
            {
                BuyerId = buyerId
            };
        }


        public void AddCartItem(Guid productId, decimal unitPrice, int quantity = 1)
        {
            if (!CartItems.Any(a => a.ProductId == productId))
            {
                _cartItems.Add(CartItem.Create(productId, unitPrice, quantity));
            }
            var existingCartItem = CartItems.FirstOrDefault(a => a.ProductId == productId);
            existingCartItem.AddQuantity(quantity);
        }

        public void RemoveEmptyItems()
        {
            _cartItems.RemoveAll(i => i.Quantity == 0);
        }

        public void SetNewBuyerId(string buyerId)
        {
            BuyerId = buyerId;
        }
    }
}
