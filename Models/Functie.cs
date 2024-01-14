using System.ComponentModel.DataAnnotations;

namespace Konya_Zoltan_Proiect_Managementul_Concediilor.Models
{
    public class Functie
    {
        public int ID { get; set; }

        [Display(Name = "nr. crt.")]
        public int NrCrt => ID;

        [Display(Name = "Nr Funcție")]
        public string NrFunctie { get; set; }

        [Display(Name = "Nume Funcție")]
        public string NumeFunctie { get; set; }
    }
}
