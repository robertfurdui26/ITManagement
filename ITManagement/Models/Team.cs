using System.ComponentModel.DataAnnotations;

namespace ITManagement.Models
{
    public class Team
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Count { get; set; }
    }
}
