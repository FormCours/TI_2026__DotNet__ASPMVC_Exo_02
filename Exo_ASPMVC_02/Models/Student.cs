using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Exo_ASPMVC_02.Models
{
    public class Student
    {
        public int Id { get; set; }

        [DisplayName("Prénom")]
        public string FirstName { get; set; }

        [DisplayName("Nom")]
        public string LastName { get; set; }

        [DisplayName("Date de naissance")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [DisplayName("Remarque")]
        public string? Remark { get; set; }

        [DisplayName("Est un·e p'tit·e con·ne")]
        public bool IsBlamed { get; set; }

        [DisplayName("Vieux·elle de")]
        [DisplayFormat(DataFormatString = "{0:d} ans")]
        public int Age
        {
            get
            {
                int age = DateTime.Today.Year - BirthDate.Year;

                if(DateTime.Today.AddYears(-age) < BirthDate)
                {
                    age--;
                }

                return age;
            }
        }
    }
}
