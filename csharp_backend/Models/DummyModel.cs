using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace csharp_backend.Models
{
    public class Dummy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DummyId { get; set; }

        [Required]
        public string Name { get; set; }

        [MaxLength(512)]
        public string Description { get; set; }

        [Required]
        [MaxLength(128)]
        public string Value { get; set; }

    }
}
