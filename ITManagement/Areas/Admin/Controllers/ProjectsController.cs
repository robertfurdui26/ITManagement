using ITManagement.Models;
using ITManagement.Models.ViewModels;
using ITManagement.Repository.IRepository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ITManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProjectsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProjectsController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult ShowProjects()
        {
            var projectsDb = _unitOfWork.Projects.GetAll(includeProperties:"Employee").ToList();
            return View(projectsDb);
        }


        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            ProjectVM projectVM = new()
            {
                EmployeeList = _unitOfWork.Employee.GetAll().Select(u => new SelectListItem
                {
                    Text = u.FirstName,
                    Value = u.Id.ToString()
                }),
                 Project = new Project()
            };

            if (id == null || id == 0)
            {
                return View(projectVM);
            }
            projectVM.Project = _unitOfWork.Projects.Get(u => u.Id == id);
            return View(projectVM);
        }

        [HttpPost]
        public IActionResult Upsert(ProjectVM projectVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string employeePath = Path.Combine(wwwRootPath, @"images\projects");

                    if (!string.IsNullOrEmpty(projectVM.Project.ImageUrl))
                    {
                        var oldPath = Path.Combine(wwwRootPath, projectVM.Project.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldPath))
                        {
                            System.IO.File.Delete(oldPath);
                        }
                    }
                    using (var fileStream = new FileStream(Path.Combine(employeePath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    projectVM.Project.ImageUrl = @"\images\projects\" + fileName;
                }

                if (projectVM.Project.Id == 0)
                {
                    _unitOfWork.Projects.Add(projectVM.Project);
                }
                else
                {
                    _unitOfWork.Projects.Update(projectVM.Project);
                }
                _unitOfWork.Save();
                TempData["success"] = "Employee created successfully!";
                return RedirectToAction("ShowProjects");
            }
            else
            {
                projectVM.EmployeeList = _unitOfWork.Employee.GetAll().Select(u => new SelectListItem
                {
                    Text = u.FirstName,
                    Value = u.Id.ToString()
                });
                return View(projectVM);
            }
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Project> projectList = _unitOfWork.Projects.GetAll(includeProperties: "Employee").ToList();
            return Json(new { Data = projectList });
        }

        [HttpDelete]

        public IActionResult Delete(int? id)
        {
            var projectDeleted = _unitOfWork.Projects.Get(u => u.Id == id);
            if (projectDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath,
                          projectDeleted.ImageUrl.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }
            _unitOfWork.Projects.Remove(projectDeleted);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successfully!" });
            #endregion
        }
    }
}
