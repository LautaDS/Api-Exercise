using System.ComponentModel.DataAnnotations;

namespace UnitOfWork.Models
{
    public class Pelicula
    {
        [Key]
        public int id { get; set; }
        [Required] 
        public string? nombre { get; set; }
        
        public string? genero { get; set; }

        public DateTime? dateTime { get; set; }

    }
}
