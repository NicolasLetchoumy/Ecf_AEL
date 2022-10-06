using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECF_auto_ecole.Models
{
    [Table("LECON")]
    public partial class Lecon
    {
        [Key]
        [Column("modèle véhicule")]
        [StringLength(50)]
        [Unicode(false)]
        public string ModèleVéhicule { get; set; } = null!;
        [Key]
        [Column("date heure", TypeName = "date")]
        public DateTime DateHeure { get; set; }
        [Key]
        [Column("id élève")]
        public int IdÉlève { get; set; }
        [Key]
        [Column("id moniteur")]
        public int IdMoniteur { get; set; }
        [Column("durée")]
        public int Durée { get; set; }

        [ForeignKey("DateHeure")]
        [InverseProperty("Lecons")]
        public virtual Calendrier DateHeureNavigation { get; set; } = null!;
        [ForeignKey("IdMoniteur")]
        [InverseProperty("Lecons")]
        public virtual Moniteur IdMoniteurNavigation { get; set; } = null!;
        [ForeignKey("IdÉlève")]
        [InverseProperty("Lecons")]
        public virtual Eleve IdÉlèveNavigation { get; set; } = null!;
        [ForeignKey("ModèleVéhicule")]
        [InverseProperty("Lecons")]
        public virtual Modele ModèleVéhiculeNavigation { get; set; } = null!;
        /// <summary>
        /// JE N'ai pas réussi a faire les clé étrangerère dans le code et je ne veux pas tout recommencer a zéro
        /// DONC
        /// je ne ferais pas l'affichage du nom de l'élève et du rendez-vous
        /// </summary>
       /* [ForeignKey("NomÉlève")]
        [InverseProperty("Eleve")]
        public virtual Eleve NomÉlève { get; set; } = null!;

        [ForeignKey("PrénomÉlève")]
        [InverseProperty("Eleve")]
        public virtual Eleve PrénomÉlève { get; set; } = null!;*/
       
    }
}
