using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECF_auto_ecole.Models
{
    [Table("ELEVE")]
    public partial class Eleve
    {
        public Eleve()
        {
            Lecons = new HashSet<Lecon>();
        }

        [Key]
        [Column("id élève")]
        public int IdÉlève { get; set; }
        [Column("nom élève")]
        [StringLength(50)]
        [Unicode(false)]
        public string NomÉlève { get; set; } = null!;
        [Column("prénom élève")]
        [StringLength(50)]
        [Unicode(false)]
        public string PrénomÉlève { get; set; } = null!;
        [Column("code")]
        public bool Code { get; set; }
        [Column("conduite")]
        public bool Conduite { get; set; }
        [Column("date naissance", TypeName = "date")]
        public DateTime DateNaissance { get; set; }

        [InverseProperty("IdÉlèveNavigation")]
        public virtual ICollection<Lecon> Lecons { get; set; }
    }
}
