using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    [Table("StatusOfTask")]
    public class StatusModel
    {
        [Key]
        public int StatusId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
