using ITManagement.Models;
using ITManagement.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;


namespace ITManagement.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class DepartamentController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public DepartamentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult ShowDepartament()
        {
            var departamentObj = _unitOfWork.Departament.GetAll().ToList();
            return View(departamentObj);
        }

        [HttpGet]
        public IActionResult CreateDepartament()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateDepartament(Departament departamentObj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Departament.Add(departamentObj);
                _unitOfWork.Save();
                TempData["success"] = "Departament created succesfuly";

                return RedirectToAction("ShowDepartament");
            }
            return View();
        }

        [HttpGet]
        public IActionResult EditDepartament(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Departament? departamentDb = _unitOfWork.Departament.Get(u => u.Id == id);
            if (departamentDb == null)
            {
                return NotFound();
            }
            return View(departamentDb);
        }

        [HttpPost]
        public IActionResult EditDepartament(Departament departament)
        {
            if (!ModelState.IsValid)
            {
                return NotFound(ModelState);
            }
            else
            {
                _unitOfWork.Departament.Update(departament);
                _unitOfWork.Save();
                TempData["success"] = "Departament update succesfuly";

                return RedirectToAction("ShowDepartament");
            }
            return View();
        }

        [HttpGet]
        public IActionResult DeleteDepartament(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Departament? departamentDb = _unitOfWork.Departament.Get(u => u.Id == id);
            if (departamentDb == null)
            {
                return NotFound();
            }
            return View(departamentDb);
        }

        [HttpPost, ActionName("DeleteDepartament")]
        public IActionResult DeleteDep(int? id)
        {
            Departament? departamentDb = _unitOfWork.Departament.Get(u => u.Id == id);

            if (departamentDb == null)
            {
                return NotFound();
            }
            _unitOfWork.Departament.Remove(departamentDb);
            _unitOfWork.Save();
            TempData["success"] = "Departament deleted succesfuly";

            return RedirectToAction("ShowDepartament");

        }

    }
}
