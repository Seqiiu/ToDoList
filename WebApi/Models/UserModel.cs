using System;
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
        public string Name { get; set; }
        public string ?LastName { get; set; }
        public string ?Email { get; set; }
        [Required]
        public DateTime DateOfCreated { get; set; }

    }
}
