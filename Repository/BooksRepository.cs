using BookWebAPI.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookWebAPI.Repository
{
    public class BooksRepository : IBooksInterface
    {
        protected BooksDBContext _bookContext;
        public BooksRepository(BooksDBContext booksDBContext)
        {
            _bookContext = booksDBContext;
        }

        public IEnumerable<Books> AddBooks(Books addbook)
        {
            _bookContext.books.Add(addbook);
            _bookContext.SaveChanges();
            return _bookContext.books.ToList();
        }

        public IEnumerable<Books> GetAllBooks()
        {
            return _bookContext.books.ToList();
        }

        public Books GetBooks(int id)
        {
            return _bookContext.books.Find(id);
        }

        public IEnumerable<Books> UpdateBooks(int id, Books updateBooks)
        {
            if (_bookContext != null)
            {
                var bok = _bookContext.books.Find(id);
                _bookContext.books.Update(updateBooks);
                _bookContext.SaveChanges();
                return _bookContext.books.ToList();
            }
            else
            {
                return null;
            }
        }
    }
}
