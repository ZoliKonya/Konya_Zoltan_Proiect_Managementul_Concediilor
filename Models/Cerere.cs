using System.ComponentModel.DataAnnotations;

namespace Konya_Zoltan_Proiect_Managementul_Concediilor.Models
{
    public class Cerere
    {
        public int ID { get; set; }

        [Display(Name = "nr. crt.")]
        public int NrCrt => ID;

        [Display(Name = "Angajat")]
        public int? AngajatID { get; set; }
        public Angajat? Angajat { get; set; }

        [Display(Name = "Departament")]
        public int? DepartamentID { get; set; }
        public Departament? Departament { get; set; }

        [Display(Name = "Funcție")]
        public int? FunctieID { get; set; }
        public Functie? Functie { get; set; }

        [Display(Name = "Categorie Cerere")]
        public int? CategorieCerereID { get; set; }
        public CategorieCerere? CategorieCerere { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data de început")]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data de sfârșit")]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Stare Cerere")]
        public int? StareCerereID { get; set; }
        public StareCerere? StareCerere { get; set; }
    }
}
