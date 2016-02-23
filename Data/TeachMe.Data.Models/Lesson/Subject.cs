namespace TeachMe.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using TeachMe.Data.Common.Models;

    public class Subject : BaseModel<int>
    {
        public Subject()
        {
            this.Lessons = new HashSet<Lesson>();
        }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}
