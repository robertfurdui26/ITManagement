using ITManagement.Models;
using ITManagement.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace ITManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeamController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TeamController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult ShowTeam()
        {
            var teamDb = _unitOfWork.Team.GetAll().ToList();
            return View(teamDb);
        }

        [HttpGet]
        public IActionResult CreateTeam()
        {
            return View();
        }

        [HttpPost]

        public IActionResult CreateTeam(Team teabDb)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Team.Add(teabDb);
                _unitOfWork.Save();
                TempData["success"] = "Team created succesfuly";

                return RedirectToAction("ShowTeam");
            }

            return View();
        }

        [HttpGet]
        public IActionResult EditTeam(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Team? teamDb = _unitOfWork.Team.Get(u => u.Id == id);
            if (teamDb == null)
            {
                return NotFound();
            }
            return View(teamDb);
        }

        [HttpPost]

        public IActionResult EditTeam(Team teabDb)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            else
            {
                _unitOfWork.Team.Update(teabDb);
                _unitOfWork.Save();
                TempData["success"] = "Team updated succesfuly";

                return RedirectToAction("ShowTeam");
            }
            return View();
        }

        [HttpGet]

        public IActionResult DeleteTeam(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Team? teamDb = _unitOfWork.Team.Get(u => u.Id == id);

            if (teamDb == null)
            {
                return NotFound();
            }
            return View(teamDb);
        }

        [HttpPost, ActionName("DeleteTeam")]

        public IActionResult DeletePost(int? id)
        {
            Team? teamDb = _unitOfWork.Team.Get(u => u.Id == id);

            if (teamDb == null)
            {
                return NotFound();
            }
            _unitOfWork.Team.Remove(teamDb);
            _unitOfWork.Save();
            TempData["success"] = "Team deleted succesfuly";
            return RedirectToAction("ShowTeam");
        }
    }
}
