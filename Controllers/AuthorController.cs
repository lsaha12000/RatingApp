using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RatingApp.Models;

namespace RatingApp.Controllers
{
    public class AuthorController : Controller
    {
        private ContextClass _context;
        public AuthorController()
        {
            _context = new ContextClass();
        }
        public IActionResult BookDetails(string id)
        {
            if (HttpContext.Session.GetString("email") == null) { return RedirectToAction("Home", "Admin"); }
            var data = _context.Books.Where(x => x.Author.emailId.Equals(id)).ToList();
            if (data.IsNullOrEmpty()) 
            {
                if (HttpContext.Session.GetString("type") != "Author") return View("NotFound");
                return View("AddBook"); 
            }
            else return View(data);
        }
        public IActionResult Home()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Home(Author author)
        {
           Author a =  _context.Authors.Where(x=>x.emailId.Equals(author.emailId)&&x.Password.Equals(author.Password)).FirstOrDefault();
            HttpContext.Session.SetString("email", a.emailId);
            HttpContext.Session.SetString("type", "Author");
            HttpContext.Session.SetString("name", a.Name);
            return RedirectToAction("BookDetails","Author",new { id=a.emailId });
        }
        public IActionResult AddBook()
        {
            if (HttpContext.Session.GetString("email") != null && HttpContext.Session.GetString("type").Equals("Author"))
                return View();
            else return View("NotFound");
        }
        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            book.Author = _context.Authors.Find(HttpContext.Session.GetString("email"));
            _context.Books.Add(book);
            _context.SaveChanges();
            return RedirectToAction("BookDetails","Author",new {id=book.Author.emailId});
        }
        public IActionResult Register()
        {
            return View();
        }
    }
}
