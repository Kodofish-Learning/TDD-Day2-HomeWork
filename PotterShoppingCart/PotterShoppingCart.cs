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
            decimal rate = getRate(_ShoppingItems.Count);

            decimal totalPrice = rate * _ShoppingItems.Sum(x => x.Price);

            return totalPrice;
        }

        private decimal getRate(int count)
        {
            decimal rate = 1;
            if (count <= 3)
                return (rate - (decimal)((_ShoppingItems.Count - 1) * 0.05));
            else
                return rate - (decimal)((_ShoppingItems.Count) * 0.05);
        }
    }
}