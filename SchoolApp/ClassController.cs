using Microsoft.AspNetCore.Mvc;

namespace SchoolApp
{
    public class ClassController : Controller
    {
        public IActionResult ClassList()
        {
            return View();
        }

        public IActionResult ClassEditor()
        {
            return View();
        }
    }
}
