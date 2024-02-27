using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MvcMovieContext _context;

        public MoviesController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: Movies
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return _context.Movie != null ?
                        View(await _context.Movie.ToListAsync()) :
                        Problem("Entity set 'MvcMovieContext.Movie'  is null.");
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Movie == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            ViewData["studios"] = _context.Studio.ToList();
            ViewData["artists"] = _context.Artist.ToList();
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price,StudioId,Artists")] NewMovieInputModel movie)
        {
            if (ModelState.IsValid)
            {
                var _studio = _context.Studio.Find(movie.StudioId)!;
                var _movie = new Movie
                {
                    Title = movie.Title,
                    ReleaseDate = movie.ReleaseDate,
                    Genre = movie.Genre,
                    Price = movie.Price,
                    Studio = _studio,
                    Artists = new List<Artist>()
                };

                foreach (var artistId in movie.Artists)
                {
                    var _artist = _context.Artist.FirstOrDefault(a => a.Id == artistId)!;
                    Console.WriteLine($"Text: {artistId} - {_artist.Name}");
                    _movie.Artists.Add(_artist);
                }

                _context.Add(_movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Movie == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie.FindAsync(id);
            var _studios = await _context.Studio.ToListAsync();
            var _artists = await _context.Artist.ToListAsync();

            if (movie == null)
            {
                return NotFound();
            }

            ViewData["studios"] = _studios;
            ViewData["artists"] = _artists;

            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price,StudioId,Artists")] EditMovieInputModel movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var _movie = _context.Movie.Find(movie.Id)!;

                    _movie.Title = movie.Title;
                    _movie.ReleaseDate = movie.ReleaseDate;
                    _movie.Genre = movie.Genre;
                    _movie.Price = movie.Price;
                    _movie.Studio = _context.Studio.Find(movie.StudioId)!;
                    _movie.Artists = new List<Artist>();

                    foreach (var artistId in movie.Artists)
                    {
                        var _artist = _context.Artist.FirstOrDefault(a => a.Id == artistId)!;
                        _movie.Artists.Add(_artist);
                    }

                    _context.Update(_movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
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
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Movie == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Movie == null)
            {
                return Problem("Entity set 'MvcMovieContext.Movie'  is null.");
            }
            var movie = await _context.Movie.FindAsync(id);
            if (movie != null)
            {
                _context.Movie.Remove(movie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return (_context.Movie?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
