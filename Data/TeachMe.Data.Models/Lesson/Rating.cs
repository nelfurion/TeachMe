namespace TeachMe.Data.Models
{
    using Common.Models;

    public class Rating : BaseModel<int>
    {
        public virtual Lesson Lesson { get; set; }

        public int Value { get; set; }
    }
}
