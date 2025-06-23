using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab1_final.Models
{
    [Table("usuario")]
    public class Usuario
    {
        [Key]
        public int id { get; set; }
        public string user { get; set; }
        public string password { get; set; }
    }
}
