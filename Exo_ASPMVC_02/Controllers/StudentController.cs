using Exo_ASPMVC_02.Models;
using Exo_ASPMVC_02.Services;
using Exo_ASPMVC_02.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Exo_ASPMVC_02.Controllers
{
    [Route("Apprenant/{action}/{id?}")]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        public StudentController()
        {
            _studentService = new StudentService();
        }


        public IActionResult Index()
        {
            IEnumerable<Student> students = _studentService.GetAll();
            return View(students);
        }

        public IActionResult Details([FromRoute]int id)
        {
            Student? student = _studentService.GetById(id);

            if(student is null)
            {
                TempData["ErrorMessage"] = "L'élément n'a pas été trouvé !";
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // ← Vérification en phishing 🐟 (Permet de prévenir l'utilisateur)
        public IActionResult Create([FromForm]StudentForm data)
        {
            // Test de garde → Validation du contenu du formulaire (ModelState)
            if(!ModelState.IsValid)
            {
                return View(data);
            }

            // Donnée à ajouter
            Student studentToAdd = new Student
            {
                FirstName = data.FirstName,
                LastName = data.LastName,
                BirthDate = data.BirthDate,
                Remark = data.Remark,
                IsBlamed = data.IsBlamed
            };

            // Test de doublon
            if(_studentService.CheckDuplicate(studentToAdd))
            {
                ModelState.AddModelError("", "L'apprenant est déjà présent !");
                return View(data);
            }

            // Traitement du formulaire
            int studentId = _studentService.Add(studentToAdd);
            return RedirectToAction(nameof(Details), new { Id = studentId });
        }

        public IActionResult Delete([FromRoute]int id)
        {
            Student? student = _studentService.GetById(id);

            if (student is null)
            {
                TempData["ErrorMessage"] = "L'élément n'a pas été trouvé !";
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirme([FromRoute] int id)
        {
            _studentService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
