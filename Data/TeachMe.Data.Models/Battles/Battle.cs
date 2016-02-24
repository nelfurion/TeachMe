namespace TeachMe.Data.Models
{
    using System.Collections.Generic;
    using TeachMe.Data.Common.Models;

    public class Battle : BaseModel<int>
    {
        public Battle()
        {
            this.Teams = new HashSet<Team>();
        }

        public virtual ICollection<Team> Teams { get; set; }
    }
}
