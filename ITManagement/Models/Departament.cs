using System.ComponentModel.DataAnnotations;

namespace ITManagement.Models
{
    public class Departament
    {
        [Key]

        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        [Range(1, 100, ErrorMessage = "Display departament must be between 1-100!")]
        public int DisplayDepartament { get; set; }



    }
}
