using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace zadatak_dev.Models
{
    public class User_Test
    {
        [Key]
        public int Id_User { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int Dob { get; set; }
    }
}
