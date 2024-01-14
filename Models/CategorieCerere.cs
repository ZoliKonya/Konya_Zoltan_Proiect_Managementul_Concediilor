using System.ComponentModel.DataAnnotations;

namespace Konya_Zoltan_Proiect_Managementul_Concediilor.Models
{
    public class CategorieCerere
    {
        public int ID { get; set; }

        [Display(Name = "nr. crt.")]
        public int NrCrt => ID;

        [Display(Name = "Nr Categorie")]
        public string NrCategorieCerere { get; set; }

        [Display(Name = "Nume Categorie")]
        public string NumeCategorieCerere { get; set; }
    }
}
