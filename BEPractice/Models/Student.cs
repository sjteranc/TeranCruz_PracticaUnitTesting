using System.ComponentModel.DataAnnotations;

namespace BEPractice.Models
{
    public class Estudiante : Person
    {
        [Required]
        [Range(0, 100)]
        public int Nota { get; set; }
    }
}