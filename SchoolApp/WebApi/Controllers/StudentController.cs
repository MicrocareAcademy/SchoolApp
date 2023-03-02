using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Entities;
using SchoolApp.WebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private SchoolDbContext _schoolDbContext;

        public StudentController()
        {
            _schoolDbContext = new SchoolDbContext();
        }

        // GET: api/<StudentController>
        [HttpGet]
        public IActionResult Get()
        {
            var studentEntities = _schoolDbContext.StudentDetails.Include(p=>p.StudentSubjects).ToList();

            var studentsData = new List<StudentModel>();

            foreach (var studentEntity in studentEntities)
            {
                // subject model create and also assign the values to properties
                var studentObj = new StudentModel
                {
                    class_id = studentEntity.ClassId,
                    student_name = studentEntity.FullName,
                    email = studentEntity.Email,
                    password = studentEntity.Password
                };

                // we will loop thrpugh subjects of students and we will take subject ids and 
                // add to list
                var subjectIds = new List<int>();
                if(studentEntity.StudentSubjects != null && studentEntity.StudentSubjects.Count > 0)
                {
                    foreach(var subject in studentEntity.StudentSubjects)
                    {
                        subjectIds.Add(subject.SubjectId);
                    }
                }

                // assing the subject ids
                studentObj.subject = subjectIds;

                studentsData.Add(studentObj);
            }

            return Ok(studentsData);
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var studentEntity = _schoolDbContext.StudentDetails.Include(p=>p.StudentSubjects).FirstOrDefault(p=>p.Id == id); 

            if (studentEntity == null)
            {
                return Ok(null);
            }

            var studentObj = new StudentModel
            {
                class_id = studentEntity.ClassId,
                student_name = studentEntity.FullName,
                email = studentEntity.Email,
                password = studentEntity.Password,
                subject = studentEntity.StudentSubjects?.Select(p => p.SubjectId).ToList()
            };

            // we will loop thrpugh subjects of students and we will take subject ids and 
            // add to list
            var subjectIds = new List<int>();
            if (studentEntity.StudentSubjects != null && studentEntity.StudentSubjects.Count > 0)
            {
                foreach (var subject in studentEntity.StudentSubjects)
                {
                    subjectIds.Add(subject.SubjectId);
                }
            }

            studentObj.subject = subjectIds;

            return Ok(studentObj);
        }

        // POST api/<StudentController>
        [HttpPost]
        public IActionResult Post(StudentModel model)
        {

            var names = model.student_name.Split(new char[] { ' ' });

            
            var studentDetail = new StudentDetail();
            studentDetail.FName = names[0];

            if (names.Length >= 2)
            {
                studentDetail.LName = names[1];
            }
            
            studentDetail.ClassId = model.class_id;
            studentDetail.Email = model.email;
            studentDetail.Password = model.password;

            
            _schoolDbContext.StudentDetails.Add(studentDetail);
            _schoolDbContext.SaveChanges();

            if (model.subject != null && model.subject.Count > 0)
            {
                
                foreach (var subjectId in model.subject)
                {
                    var studentSubject = new StudentSubject
                    {
                         StudentId = studentDetail.Id, // student was saved above
                         SubjectId = subjectId
                         
                    };

                    _schoolDbContext.StudentSubjects.Add(studentSubject);
                }

                _schoolDbContext.SaveChanges();
            }

            

            return Ok();

        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, StudentModel model)
        {
            var names = model.student_name.Split(new char[] { ' ' });


            var studentDetail = _schoolDbContext.StudentDetails.FirstOrDefault(p => p.Id == id);

            studentDetail.FName = names[0];

            if (names.Length >= 2)
            {
                studentDetail.LName = names[1];
            }

            studentDetail.ClassId = model.class_id;
            studentDetail.Email = model.email;
            studentDetail.Password = model.password;

            _schoolDbContext.StudentDetails.Update(studentDetail);

            _schoolDbContext.SaveChanges();

            return Ok();
        }
        
    }
}
