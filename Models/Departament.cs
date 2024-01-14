using System.ComponentModel.DataAnnotations;

namespace Konya_Zoltan_Proiect_Managementul_Concediilor.Models
{
    public class Departament
    {
        public int ID { get; set; }

        [Display(Name = "nr. crt.")]
        public int NrCrt => ID;

        [Display(Name = "Nr Departament")]
        public string NrDepartament { get; set; }

        [Display(Name = "Nume Departament")]
        public string NumeDepartament { get; set; }

    }
}
