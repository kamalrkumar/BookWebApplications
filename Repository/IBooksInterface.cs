using BookWebAPI.Model;
using System.Collections.Generic;

namespace BookWebAPI.Repository
{
    interface IBooksInterface
    {
        IEnumerable<Books> GetAllBooks();

        Books GetBooks(int id);

        IEnumerable<Books> AddBooks(Books addbook);

        IEnumerable<Books> UpdateBooks(int id, Books updateBooks);
    }
}
