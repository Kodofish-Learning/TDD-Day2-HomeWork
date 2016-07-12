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
            var bookSets = SplitSet();
            foreach (var bookItems in bookSets)
            {
                decimal rate = getRate(bookItems.SetItem.Count);

                bookItems.SetPrice = rate * bookItems.SetItem.Sum(x => x.Price);
            }

            return bookSets.Sum(x => x.SetPrice);
        }

        private List<BookSet> SplitSet()
        {
            Book[] bookArray = new Book[_ShoppingItems.Count];
            _ShoppingItems.CopyTo(bookArray);
            var cloneShoppingItems = bookArray.ToList();

            List<BookSet> bookSets = new List<BookSet>();
            int MaxSets = cloneShoppingItems.Max(x => x.Amount);
            for (int i = 0; i < MaxSets; i++)
            {
                List<Book> books = new List<Book>();
                foreach (var item in cloneShoppingItems)
                {
                    if (item.Amount > 0)
                    {
                        item.Amount -= 1;
                        books.Add(new Book { Amount = 1, Price = item.Price, Name = item.Name });
                    }
                }
                bookSets.Add(new BookSet { SetItem = books, SetPrice = 0 });
            }
            return bookSets;
        }

        private decimal getRate(int count)
        {
            decimal rate = 1;
            if (count <= 3)
                return (rate - (decimal)((count - 1) * 0.05));
            else
                return rate - (decimal)((count) * 0.05);
        }
    }
}