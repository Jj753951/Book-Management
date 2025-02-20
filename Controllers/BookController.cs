using Book_Management.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace Book_Management.Controllers
{
    public class BookController : Controller
    {
        private static List<BookModel> books = new List<BookModel>()
        {
            new BookModel() {Id = 1, Title = "Green", Author = "Artur", Genre = "Kniga", Year = 1923 }
        };

        [HttpGet]

        public IActionResult Index()
        {
            return View(books);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BookModel model)
        {
            if (ModelState.IsValid)
            {
                books.Add(model);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var book = books.FirstOrDefault(x => x.Id == id);
            if (book == null)
            {
                return NotFound();

            }

            return View(book);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var book = books.FirstOrDefault(x => x.Id == id);
            if (book != null)
            {
                books.Remove(book);

            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var book = books.FirstOrDefault(x => x.Id == id);
            if (book != null)
            {
                books.Remove(book);

            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Edit(int id, BookModel updatemodel)
        {
            var book = books.FirstOrDefault(x => x.Id == id);
            if (book != null)
            {
                books.Remove(book);

            }

            return RedirectToAction(nameof(Index));
        }
    }

}