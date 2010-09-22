using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
namespace UCDMvcBootCamp.Models
{
    public class AttendeeEditModel
    {
        [HiddenInput(DisplayValue = false)]
        public int ConferenceId { get; set; }
        [HiddenInput(DisplayValue = true)]
        public string ConferenceName { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}