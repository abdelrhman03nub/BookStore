
using BookStore.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var books = _context.Books.ToList();

            return View(books);

        }



        public IActionResult Create()
        {
            ViewBag.Authors = new SelectList(_context.Authors, "Id", "Name");

            return View();
        }


        [HttpPost]
        public async Task <IActionResult> Create(Book book)
        {
            if (!ModelState.IsValid)
            {
                return View(book);
            }

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");



        }
       
        public IActionResult Edit(int id)
        {
            var book = _context.Books.Find(id);

            if(book==null)
            {
                return NotFound();

            }


            return View(book);

        }


        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (!ModelState.IsValid)
            {
                return View(book);
            }

            _context.Books.Update(book);
            _context.SaveChanges();

            return RedirectToAction("Index");

        }


        public IActionResult Delete(int id)
        {
            var book = _context.Books.Find(id);

            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }




    }
}

