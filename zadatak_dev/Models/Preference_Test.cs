using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace zadatak_dev.Models
{
    public class Preference_Test
    {
        [Key]
        public int Id_Preference { get; set; }
        public string Zanr_Knjige { get; set; }
        public string Naziv_Knjige { get; set; }
        public string Autor_Knjige{ get; set; }

    
    }
}
    