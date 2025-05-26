using System.ComponentModel.DataAnnotations;

namespace BEPractice.Models
{
    public class Person
    {
        public int CI { get; set; }
        public required string Nombre { get; set; }
    }
}
