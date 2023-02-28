using Microsoft.AspNetCore.Mvc;

namespace SchoolApp
{
    public class StudentController : Controller
    {
        public IActionResult StudentsList()
        {
            return View();
        }

        public IActionResult StudentEditor()
        {
            return View();
        }
    }
}
