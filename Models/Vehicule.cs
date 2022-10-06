using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECF_auto_ecole.Models
{
    [Table("VEHICULE")]
    public partial class Vehicule
    {
        [Key]
        [Column("n°immatriculation")]
        [StringLength(9)]
        [Unicode(false)]
        public string NImmatriculation { get; set; } = null!;
        [Column("modèle véhicule")]
        [StringLength(50)]
        [Unicode(false)]
        public string ModèleVéhicule { get; set; } = null!;
        [Column("état")]
        public bool État { get; set; }

        [ForeignKey("ModèleVéhicule")]
        [InverseProperty("Vehicules")]
        public virtual Modele ModèleVéhiculeNavigation { get; set; } = null!;
    }
}
