using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECF_auto_ecole.Models
{
    [Table("MODELE")]
    public partial class Modele
    {
        public Modele()
        {
            Lecons = new HashSet<Lecon>();
            Vehicules = new HashSet<Vehicule>();
        }

        [Key]
        [Column("modèle véhicule")]
        [StringLength(50)]
        [Unicode(false)]
        public string ModèleVéhicule { get; set; } = null!;
        [Column("marque")]
        [StringLength(50)]
        [Unicode(false)]
        public string Marque { get; set; } = null!;
        [Column("année")]
        [StringLength(4)]
        public string Année { get; set; } = null!;
        [Column("date achat", TypeName = "date")]
        public DateTime DateAchat { get; set; }

        [InverseProperty("ModèleVéhiculeNavigation")]
        public virtual ICollection<Lecon> Lecons { get; set; }
        [InverseProperty("ModèleVéhiculeNavigation")]
        public virtual ICollection<Vehicule> Vehicules { get; set; }
    }
}
