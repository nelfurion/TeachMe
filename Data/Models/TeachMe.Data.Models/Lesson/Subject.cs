namespace TeachMe.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Subject
    {
        public Subject()
        {
            this.Lessons = new HashSet<Lesson>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}
