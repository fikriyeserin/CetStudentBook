using CetStudentBook.Data;
using CetStudentBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CetStudentBook.Controllers 
{
    public class BooksController : Controller

    {
        
        private readonly ApplicationDbContext context;

        public BooksController(ApplicationDbContext _context)
        {
            context = _context;
        }

        public IActionResult Index()
        {
            List<Book> books = context.Books.ToList();
            return View(books);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                context.Books.Add(book);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        public IActionResult Edit(int id)
        {
            var book = context.Books.Find(id);

            if (book == null)
                return NotFound();

            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                context.Books.Update(book);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(book);
        }

        public IActionResult Delete(int id)
        {
            var book = context.Books.Find(id);

            if (book == null)
                return NotFound();

            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var book = context.Books.Find(id);

            if (book == null)
                return NotFound();

            context.Books.Remove(book);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
