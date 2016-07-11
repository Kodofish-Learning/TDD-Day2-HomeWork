using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotterShoppingCart
{
    public class PotterShoppingCart
    {
        private List<Book> _ShoppingItems;

        public void AddShoppingItem(List<Book> books)
        {
            this._ShoppingItems = books;
        }

        public decimal getTotalPrice()
        {
            decimal rate = 1;

            decimal totalPrice = (rate - (decimal)((_ShoppingItems.Count - 1) * 0.05)) * _ShoppingItems.Sum(x => x.Price);

            return totalPrice;
        }
    }
}