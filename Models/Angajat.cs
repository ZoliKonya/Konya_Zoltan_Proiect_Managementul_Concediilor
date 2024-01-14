using System.ComponentModel.DataAnnotations;

namespace Konya_Zoltan_Proiect_Managementul_Concediilor.Models
{
    public class Angajat
    {
        public int ID { get; set; }

        [Display(Name = "nr. crt.")]
        public int NrCrt => ID;

        [Display(Name = "Nume")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage = "Prenumele trebuie sa inceapa cu majuscula (ex. Ana sau Ana Maria sau AnaMaria")]
        [StringLength(30, MinimumLength = 3)]
        public string? FirstName { get; set; }

        [Display(Name = "Prenume")]
        [RegularExpression(@"^[A-Z]+[a-z\s]*$")]
        [StringLength(30, MinimumLength = 3)]
        public string? LastName { get; set; }

        [Display(Name = "Full Name")]
        public string? FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        [Display(Name = "Departament")]
        public int? DepartamentID { get; set; }
        public Departament? Departament { get; set; }

        [Display(Name = "Funcție")]
        public int? FunctieID { get; set; }
        public Functie? Functie { get; set; }

        [StringLength(70)]
        public string? Adress { get; set; }

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Adresa de email trebuie să conțină caracterul @")]
        public string Email { get; set; }

        [RegularExpression(@"^\(?[0]+([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Prima cifra introdusa sa fie 0 // Telefonul trebuie sa fie de forma '0722-123-123' sau'0722.123.123' sau '0722 123 123'")]
        public string? Phone { get; set; }
        
    }
}
