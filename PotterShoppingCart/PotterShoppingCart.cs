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

        /// <summary>
        /// 計算總金額
        /// </summary>
        /// <returns></returns>
        public decimal getTotalPrice()
        {
            var bookSets = SplitSet();
            foreach (var bookItems in bookSets)
            {
                decimal rate = getRate(bookItems.SetItems.Count);

                bookItems.Price = rate * bookItems.SetItems.Sum(x => x.Price);
            }

            return bookSets.Sum(x => x.Price);
        }

        /// <summary>
        /// 計算買的書有幾套
        /// </summary>
        /// <returns></returns>
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
                bookSets.Add(new BookSet { SetItems = books, Price = 0 });
            }
            return bookSets;
        }

        /// <summary>
        /// 計算折扣比例
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
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