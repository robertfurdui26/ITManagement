using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ITManagement.Models.ViewModels
{
    public class EmployeeVM
    {
        public Employee Employee   { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> DepartamentList { get; set; }
    }
}
