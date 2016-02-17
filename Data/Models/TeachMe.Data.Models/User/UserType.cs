namespace TeachMe.Data.Models
{
    using Common;
    using System.ComponentModel.DataAnnotations;

    public class UserType
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(Constants.UserTypeNameMaxLength)]
        [MinLength(Constants.UserTypeNameMinLength)]
        public string Name { get; set; }
    }
}