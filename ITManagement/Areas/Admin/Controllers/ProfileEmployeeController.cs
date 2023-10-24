using ITManagement.Models;
using ITManagement.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace ITManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProfileEmployeeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProfileEmployeeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
       
    }
}
