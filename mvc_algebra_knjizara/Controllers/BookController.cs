using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mvc_algebra_knjizara.Models;
using mvc_algebra_knjizara.Repository;

namespace mvc_algebra_knjizara.Controllers
{
    public class BookController : Controller
    {
        private BooksRepository _books;

        public BookController()
        {
            _books = new BooksRepository();
        }

        // GET: BookController
        public ActionResult Index()
        {
            var books = _books.GetBooks();
            return View(books);
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            var book=_books.GetBookById(id);
            if (book == null) return RedirectToAction("Index");
            return View(book);
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            Book b = new Book();
            b.BookId = 0;
            return View(b);
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            try
            {
                _books.CreateNewBook(book);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("BookId",ex.Message);
                return View(book);
            }
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            var book = _books.GetBookById(id);
            if (book == null) return RedirectToAction("Index");
            return View(book);
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Book book)
        {
            try
            {
                _books.UpdateBook(book);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(book);
            }
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            var book = _books.GetBookById(id);
            if (book == null) return RedirectToAction("Index");
            return View(book);
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,Book book)
        {
            try
            {
                _books.DeleteBook(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(book);
            }
        }
    }
}
