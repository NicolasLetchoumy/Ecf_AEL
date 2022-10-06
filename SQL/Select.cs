using Microsoft.EntityFrameworkCore;
using ECF_auto_ecole.Models;
using System;
using System.Drawing;

namespace ECF_auto_ecole.SQL
{
    public class Select
    {
       /* public List<Eleve> SelectionEleve()
        {
            /// UNE ERREUR DE DEDOUBLEMENT QUI NE DEVRAIS PAS APARAITRE JE NE COMPREND PAS
            var test = new ECF_AELContext();
            var selection = test.Eleves
                            .FromSqlRaw("SELECT * from ELEVE inner join LECON ON ELEVE.[id élève] = LECON.[id élève] inner join CALENDRIER ON LECON.[date heure] = CALENDRIER.[date heure]")
                            .ToList();
            return selection;
        }*/
      
    }
}
