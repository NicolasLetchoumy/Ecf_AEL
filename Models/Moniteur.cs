using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECF_auto_ecole.Models
{
    [Table("MONITEUR")]
    public partial class Moniteur
    {
        public Moniteur()
        {
            Lecons = new HashSet<Lecon>();
        }

        [Key]
        [Column("id moniteur")]
        public int IdMoniteur { get; set; }
        [Column("nom moniteur")]
        [StringLength(50)]
        [Unicode(false)]
        public string NomMoniteur { get; set; } = null!;
        [Column("prénom moniteur")]
        [StringLength(50)]
        [Unicode(false)]
        public string PrénomMoniteur { get; set; } = null!;
        [Column("date naissance", TypeName = "date")]
        public DateTime DateNaissance { get; set; }
        [Column("date embauche", TypeName = "date")]
        public DateTime DateEmbauche { get; set; }
        [Column("activité")]
        public bool Activité { get; set; }

        [InverseProperty("IdMoniteurNavigation")]
        public virtual ICollection<Lecon> Lecons { get; set; }
    }
}
