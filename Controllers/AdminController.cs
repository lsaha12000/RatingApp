using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RatingApp.Models;

namespace RatingApp.Controllers
{
    public class AdminController : Controller
    {
        private ContextClass _context;
        public AdminController()
        {
            _context = new ContextClass();
        }
        public IActionResult Home()
        {
            if (HttpContext.Session.GetString("email") != null) { return RedirectToAction("ListAuthors"); }
            return View();
        }
        [HttpPost]
        public IActionResult Home(Admin admin)
        {

            Admin a = _context.Admins.Where(c => c.emailId.Equals(admin.emailId) && c.password.Equals(admin.password)).FirstOrDefault();
            if (a == null)
            {
                ViewBag.msg = "User name of password is incorrect";
                return View();
            }
            else
            {
                HttpContext.Session.SetString("email", a.emailId);
                HttpContext.Session.SetString("type", "Admin");
                return RedirectToAction("ListAuthors");
            }
        }
        public IActionResult ListAuthors()
        {
            if (HttpContext.Session.GetString("email") == null) { return RedirectToAction("Home"); }
            return View(_context.Authors.Include(x=>x.books));
        }
        public IActionResult ListBooks()
        {
            if (HttpContext.Session.GetString("email") == null) { return RedirectToAction("Home"); }
        
            return View(_context.Books.Include(x=>x.Author));
        }
        public IActionResult Logout() { 
            HttpContext.Session.Clear();
            return RedirectToAction("Home");
        }
        public IActionResult Register() { return View(); }
        [HttpPost]
        public IActionResult Register(Admin admin)
        {
            if (HttpContext.Session.GetString("email") == null) return RedirectToAction("Home");
            if(_context.Admins.Find(admin.emailId)!=null) { ViewBag.msg = "email alredy exixt"; return View(); }
            _context.Admins.Add(admin);
            _context.SaveChanges();
            return RedirectToAction("ListAuthors");
        }

        public IActionResult DeleteAuthor(string id) 
        {
            return View(_context.Authors.Include(x=>x.books).FirstOrDefault(c=>c.emailId.Equals(id)));
        }

        [HttpPost]
        [ActionName("DeleteAuthor")]
        public IActionResult DeleteAuthorConfirm(string emailId) 
        { 
            _context.Authors.Remove(_context.Authors.Find(emailId));
            //var data = _context.Books.Where(b => b.Author.emailId.Equals(emailId));
            //foreach(var d in data)
            //{
            //    d.Author = null;
            //}
            _context.SaveChanges();
            return RedirectToAction("ListAuthors");
        }
        public IActionResult DeleteBook(int id)
        {
            return View(_context.Books.Find(id));
        }

        [HttpPost]
        [ActionName("DeleteBook")]
        public IActionResult DeleteBookConfirm(int Id)
        {
            _context.Books.Remove(_context.Books.Find(Id));
            //var data = _context.Books.Where(b => b.Author.emailId.Equals(emailId));
            //foreach(var d in data)
            //{
            //    d.Author = null;
            //}
            _context.SaveChanges();
            return RedirectToAction("ListBooks");
        }
        [AcceptVerbs("Get","Post")]
        public IActionResult AdminExist(string emailId)
        {
            if(_context.Admins.Find(emailId) == null) return Json(true);
            else return Json($"Email {emailId} is alredy in use");
        }

    }
}
