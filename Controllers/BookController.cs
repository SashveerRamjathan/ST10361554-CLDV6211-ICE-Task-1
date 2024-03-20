using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CLDV6211_ICE_Task_1.Data;
using CLDV6211_ICE_Task_1.Models;



namespace CLDV6211_ICE_Task_1.Controllers
{
    public class BookController : Controller
    {
        private readonly CLDV6211_ICE_Task_1Context _context;

        public BookController(CLDV6211_ICE_Task_1Context context)
        {
            _context = context;
        }

        // GET: Book
        public async Task<IActionResult> Index(string searchString)
        {
            if (_context.Book == null)
            {
                return Problem("Entity set 'CLDV6211_ICE_Task_1Context.Book' is null.");
            }

            var books = from b in _context.Book
                        select b;

            if (!String.IsNullOrEmpty(searchString))
            {
                // Check for an exact match for the rating
                books = books.Where(b =>
                    b.Title.Contains(searchString) ||
                    b.Author.Contains(searchString) ||
                    b.Description.Contains(searchString) ||
                    b.Price.Contains(searchString) ||
                    b.Genre.Contains(searchString) ||
                    b.Rating.Equals(searchString)
                );
            }


            return View(await books.ToListAsync());
        }


        // GET: Book/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Book/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Author,Description,ReleaseDate,Price,Genre,Rating")] Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Book/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: Book/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Author,Description,ReleaseDate,Price,Genre,Rating")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Book/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Book.FindAsync(id);
            if (book != null)
            {
                _context.Book.Remove(book);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _context.Book.Any(e => e.Id == id);
        }

        public IActionResult Favourite(int id)
        {
            var book = _context.Book.Find(id);
            if (book != null)
            {
                // Toggle favorited status
                book.IsFavorited = !book.IsFavorited;

                // Save changes to database
                _context.SaveChanges();
            }

            // Get all favorite books from the database
            var favoriteBooks = _context.Book.Where(b => b.IsFavorited).ToList();

            // Pass the favoriteBooks data to the Favorites view
            return View("Favourites", favoriteBooks);
        }

        [HttpPost]
        public IActionResult RemoveFromFavourites(int id)
        {
            var book = _context.Book.Find(id);
            if (book != null)
            {
                // Remove the book from favorites
                book.IsFavorited = false;

                // Save changes to database
                _context.SaveChanges();
            }

            // Redirect back to the favorites view
            return RedirectToAction("Favourite");
        }

       

    }
}
