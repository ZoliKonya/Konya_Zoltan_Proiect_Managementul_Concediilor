using System.ComponentModel.DataAnnotations;

namespace Konya_Zoltan_Proiect_Managementul_Concediilor.Models
{
    public class StareCerere
    {
        public int ID { get; set; }

        [Display(Name = "nr. crt.")]
        public int NrCrt => ID;

        [Display(Name = "Nr Stare")]
        public string NrStareCerere { get; set; }

        [Display(Name = "Nume Stare")]
        public string NumeStareCerere { get; set; }
    }
}
