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
        public int ?User2Id { get; set; }
        [DisplayName("Zadanie dla:")]
        public virtual User2Model User2 { get; set; }
        public int ?StatusId { get; set; }
        [DisplayName("Status")]
        public virtual StatusModel Status{ get; set; }
    }
}


