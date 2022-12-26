using InforceTask.Context;
using InforceTask.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InforceTeask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UrlController : Controller
    {
        private readonly URLContext _context;

        public UrlController(URLContext context)
        {
            _context = context;
        }

        [HttpGet]
      //  [AllowAnonymous]
        public async  Task<IActionResult> Index()
        {
            var urls = await _context.Urls.ToListAsync();
            return Ok(urls);
        }

        [HttpPost]
       // [Authorize]
        public async Task<IActionResult> AddUrl( URL url)
        {
            
            if (ModelState.IsValid)
            {
                url.CreatedBy = User.Identity.Name;
                _context.Add(url);
                await _context.SaveChangesAsync();
                return Ok(url);
            }
            return BadRequest();
            
        }
        [HttpDelete]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteAll()
        {
            foreach (var item in _context.Urls)
            {
                _context.Remove(item);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
    
            var url = await _context.Urls.FindAsync(id);
            if (User.Identity.Name == url.CreatedBy)
            {
                _context.Urls.Remove(url);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var url = await _context.Urls.FirstOrDefaultAsync(m => m.Id == id);
            if (url == null)
                return NotFound();

            return View(url);
        }

    }
}
