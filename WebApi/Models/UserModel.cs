using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    [Table("User2")]
    public class User2Model
    {
        [Key]
        public int User2Id { get; set; }
        [Required]
        [DisplayName("Imię")]
        public string Name { get; set; }
        [DisplayName("Nazwisko")]
        public string ?LastName { get; set; }
        [DisplayName("E-mail")]
        public string ?Email { get; set; }
        [Required]
        [DisplayName("Data utworzenia konta")]
        public DateTime DateOfCreated { get; set; }

    }
}
