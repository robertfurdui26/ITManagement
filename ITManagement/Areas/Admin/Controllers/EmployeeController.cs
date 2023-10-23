using ITManagement.Models;
using ITManagement.Models.ViewModels;
using ITManagement.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ITManagement.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public EmployeeController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult ShowEmployee()
        {
            var employeeeDb = _unitOfWork.Employee.GetAll(includeProperties: "Departament").ToList();
            return View(employeeeDb);
        }

        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            EmployeeVM employeeVM = new()
            {
                DepartamentList = _unitOfWork.Departament.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Employee = new Employee()
            };

            if (id == null || id == 0)
            {
                return View(employeeVM);
            }
            employeeVM.Employee = _unitOfWork.Employee.Get(u => u.Id == id);
            return View(employeeVM);
        }

        [HttpPost]
        public IActionResult Upsert(EmployeeVM employeeVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string employeePath = Path.Combine(wwwRootPath, @"images\employee");

                    if(!string.IsNullOrEmpty(employeeVM.Employee.ImageUrl))
                    {
                        var oldPath = Path.Combine(wwwRootPath,employeeVM.Employee.ImageUrl.TrimStart('\\'));
                        if(System.IO.File.Exists(oldPath))
                        {
                            System.IO.File.Delete(oldPath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(employeePath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    employeeVM.Employee.ImageUrl = @"\images\employee\" + fileName;
                }

                if(employeeVM.Employee.Id == 0)
                {
                    _unitOfWork.Employee.Add(employeeVM.Employee);
                }
                else
                {
                    _unitOfWork.Employee.Update(employeeVM.Employee);
                }

                _unitOfWork.Save();
                TempData["success"] = "Employee created successfully!";
                return RedirectToAction("ShowEmployee");
            }
            else
            {
                employeeVM.DepartamentList = _unitOfWork.Departament.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
                return View(employeeVM);
            }
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Employee> employeeList = _unitOfWork.Employee.GetAll(includeProperties: "Departament").ToList();
            return Json(new { Data = employeeList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var employeeDeleted = _unitOfWork.Employee.Get(u => u.Id == id);
            if (employeeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath,
                          employeeDeleted.ImageUrl.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }
            _unitOfWork.Employee.Remove(employeeDeleted);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successfully!" });
            #endregion
        }
    }
}
