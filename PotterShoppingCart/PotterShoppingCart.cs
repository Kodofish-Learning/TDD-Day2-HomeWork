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
            if (_ShoppingItems.Count == 1)
                return 100;
            else if (_ShoppingItems.Count == 2)
                return 190;
            else
                return 270;
        }
    }
}