using MegaExam.Models;
using MegaExam.Repository;
using Microsoft.AspNetCore.Mvc;

namespace MegaExam.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        public  StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAllStud()
        {
            var stud = _studentRepository.GetAllStud();
            return Json(stud);
        }
        [HttpPost]
        public IActionResult StudInsert(StudentModel stud)
        {
             _studentRepository.StudInsert(stud);
            return Json(new {Success = true,Message = "Record Inserted"});
        }
        [HttpPost]
        public IActionResult StudUpdate([FromBody] StudentModel stud)
        {
            _studentRepository.StudUpdate(stud);
            return Json(new {Success = true,Message ="Record Update"});
        }
        [HttpPost]
        public IActionResult StudDelete(int id)
        {
            _studentRepository.StudDelete(id);
            return Json(new { Success = true, Message = "Record Deleted" });
        }
        public IActionResult FetchbyId(int id)
        {
            var stud = _studentRepository.FetchbyId(id);
            return Json(stud);
        }
    }
}
