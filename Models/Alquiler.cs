using System.ComponentModel.DataAnnotations;

namespace UnitOfWork.Models
{
    public class Alquiler
    {
        [Key]
        public int id { get; set; }

        [Required] 
        public IEnumerable<Pelicula>? peliculas { get; set; }
        [Required]
        public DateTime? dateTime { get; set; }
        [Required]
        public int? precio { get; set; }



    }
}
