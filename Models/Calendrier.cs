using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECF_auto_ecole.Models
{
    [Table("CALENDRIER")]
    public partial class Calendrier
    {
        public Calendrier()
        {
            Lecons = new HashSet<Lecon>();
        }

        [Key]
        [Column("date heure", TypeName = "date")]
        public DateTime DateHeure { get; set; }

        [InverseProperty("DateHeureNavigation")]
        public virtual ICollection<Lecon> Lecons { get; set; }
    }
}
