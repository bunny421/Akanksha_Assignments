using System.ComponentModel.DataAnnotations;

namespace CodeFirstEFInASP.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="please enter your first name")]
        public string FirstName {  get; set; }

        [Required(ErrorMessage = "please enter your last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "please enter your email name")]
        [EmailAddress(ErrorMessage ="enter valid email")]
        public string Email {  get; set; }

        [Required(ErrorMessage = "enter your age")]
        [Range(0,100, ErrorMessage ="please enter age between 1 to 100")]
        public int Age {  get; set; }

        


    }
}
