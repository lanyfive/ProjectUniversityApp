using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;
using WebProjectUni.Data;
using WebProjectUni.Models;



namespace WebProjectUni.Controllers
{
    public class CourseController : Controller
    {

        readonly private ApplicationDbContext _db;

        public CourseController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<CourseModel> courses = _db.Course;
            return View(courses);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            CourseModel course = _db.Course.FirstOrDefault(x => x.Id == id);

            if (course == null)
            {
                return NotFound();
            }


            return View(course);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            CourseModel course = _db.Course.FirstOrDefault(x => x.Id == id);

            if (course == null)
            {
                return NotFound();
            }


            return View(course);

        }


        [HttpPost]
        public IActionResult Create(CourseModel course)
        {
            if (ModelState.IsValid)
            {
                _db.Course.Add(course);
                _db.SaveChanges();
                TempData["MensagemSucesso"] = "Registo realizado com sucesso!";

                return RedirectToAction("Index");
            }

            return View();

        }

        [HttpPost]
        public IActionResult Update(CourseModel course)
        {
            if (ModelState.IsValid)
            {
                _db.Course.Update(course);
                _db.SaveChanges();

                TempData["MensagemSucesso"] = "Alteração realizada com sucesso!";

                return RedirectToAction("Index");
            }

            TempData["MensagemErro"] = "Ocorreu algum erro no momento da alteração!";
            return View(course);
        }

        [HttpPost]
        public IActionResult Delete(CourseModel course)
        {
            if (course == null)
            {
                return NotFound();
            }

            _db.Course.Remove(course);
            _db.SaveChanges();
            TempData["MensagemSucesso"] = "Exclusão realizada com sucesso!";
            return RedirectToAction("Index");

        }

    }
}
