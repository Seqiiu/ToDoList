using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    [Table("Tasks")]
    public class TaskModel
    {
        [Key]
        public int TaskId { get; set; }
        [DisplayName("Nazwa")]
        [Required]
        public string Name { get; set; }
        [DisplayName("Opis")]
        [Required]
        public string Description { get; set; }
        public bool Done { get; set; }
    }
}
