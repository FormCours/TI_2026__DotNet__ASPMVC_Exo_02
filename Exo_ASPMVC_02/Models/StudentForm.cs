using Exo_ASPMVC_02.Attributes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Exo_ASPMVC_02.Models
{
    public class StudentForm
    {
        [Required]
        [MinLength(2), MaxLength(50)]
        [DisplayName("Prénom")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2), MaxLength(50)]
        [DisplayName("Nom")]
        public string LastName { get; set; }

        [Required]
        [DateNotInFuture]
        [DisplayName("Date de naissance")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [MaxLength(1_000)]
        [DisplayName("Remarque")]
        public string? Remark { get; set; }

        [Required]
        [DisplayName("A reçu un blame")]
        public bool IsBlamed { get; set; }
    }
}
