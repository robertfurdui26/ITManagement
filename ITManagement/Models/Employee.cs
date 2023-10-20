using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITManagement.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Date Of Hire")]

        public DateTime DateOfHire { get; set; }

        public int DepartamentId { get; set; }

        [ForeignKey("DepartamentId")]
        [ValidateNever]
        public Departament Departament { get; set; }


        [ValidateNever]
        public string ImageUrl { get; set; }


        [Required]
        public double Salary { get; set; }

        [Required]
        [Display(Name = "Date Of Birth")]

        public DateTime DateOfBirth { get; set; }

        [Required]
        [Display(Name = "Last Name")]

        public string LastName { get;  set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Street Address")]

        public string StreetAdress { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string PostalCode { get; set; }

        [Required]

        public string Country { get; set; }

        



    }
}
