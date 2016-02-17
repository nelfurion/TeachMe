using System.Collections.Generic;

namespace TeachMe.Data.Models
{
    public class Team
    {
        public Team()
        {
            this.Players = new HashSet<Player>();
        }

        public int Id { get; set; }

        public virtual ICollection<Player> Players { get; set; }

        public Battle Battle { get; set; }
    }
}
