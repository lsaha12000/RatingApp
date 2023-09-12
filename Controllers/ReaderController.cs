using Microsoft.AspNetCore.Mvc;
using RatingApp.Models;

namespace RatingApp.Controllers
{
    public class ReaderController : Controller
    {
        private ContextClass _context;
        public ReaderController()
        {
            _context = new ContextClass();
        }
    
    }
}
