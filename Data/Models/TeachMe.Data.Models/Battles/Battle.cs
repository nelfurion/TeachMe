using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeachMe.Data.Models
{
    public class Battle
    {
        public Battle()
        {
            this.Teams = new HashSet<Team>();
        }

        public int Id { get; set; }
        
        public virtual ICollection<Team> Teams { get; set; }
    }
}
