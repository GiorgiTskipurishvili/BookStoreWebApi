using BookStoreWebApi.Models;
using BookStoreWebApi.Packages;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreWebApi.Controllers
{   
    
    [Route("api/[controller]")]
    [ApiController]
    public class BookStoreController : Controller
    {

        [HttpPost]
        public void AddBook(BookStore book)
        {
            var package = new PKG_BOOKSTORE();
            package.add_book(book);
        }



        [HttpGet]
        public List<BookStore> GetBooks()
        {
            var package = new PKG_BOOKSTORE();
            List<BookStore> books = new List<BookStore>();
            books = package.get_books();
            return books;
        }



        [HttpDelete("{id}")]
        public void DeleteUser(int id)
        {
            var package = new PKG_BOOKSTORE();
            BookStore book= new BookStore();
            book.Id = id;
            package.delete_book(book);
        }


        [HttpPut("{id}")]
        public void UpdateBook(BookStore book)
        {
            var package = new PKG_BOOKSTORE();
            package.update_book(book);
        }


        [HttpGet("{id}")]
        public BookStore GetBookById(int id)
        {
            var package = new PKG_BOOKSTORE();
            BookStore book = new BookStore();
            book.Id = id;
            return package.get_book_by_id(book);
        }

    }
}
