using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ITManagement.Models.ViewModels
{
    public class ProjectVM
    {
        public Project Project { get; set; }

        [ValidateNever]

        public IEnumerable<SelectListItem> EmployeeList { get; set; }
    }
}
