using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Entities;

namespace SchoolApp
{
    public class StudentController : Controller
    {
        public IActionResult StudentsList()
        {
            // we are creating an instance of SchoolDBContext(which is inheriting from DBContext)
            // DBCOntext instance represents a session with database, where we can query data from database and 
            // update instance of entities to the database

            var schoolDbContext = new SchoolDbContext();

            //we are fetching all students 
            //schoolDbContext.StudentDetails, we are going to query on studentdetails entitiy
            // if we just kept .ToList(), it means we are fetching all data of students 

            var students = schoolDbContext.StudentDetails.Include(p => p.Class).ToList();

            //.Include(p=>p.Class) , i am telling entity framework to bring the 
            // students details along with class(which is navigation property)

            return View(students); // we are passing the students list to the view 

            // so it means View->Model (IList<StudentDetails)
            // whenever a view binded with Model, we called at Strongly Typed View 

        }

        public IActionResult StudentEditor()
        {
            return View();
        }
    }
}
