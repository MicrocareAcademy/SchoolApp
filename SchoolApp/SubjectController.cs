using Microsoft.AspNetCore.Mvc;

namespace SchoolApp
{
    public class SubjectController : Controller
    {
        public IActionResult SubjectsList()
        {
            return View();
        }

        public IActionResult SubjectEditor()
        {
            return View();
        }
    }
}
