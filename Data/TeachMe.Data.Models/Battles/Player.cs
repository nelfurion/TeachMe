using TeachMe.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachMe.Data.Models
{ 
    public class Player
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int TeamId { get; set; }

        public virtual Team Team { get; set; }
    }
}
