using System.ComponentModel.DataAnnotations;

namespace Nikesh.Publisher.ViewModels
{
    public class InformationViewModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName{ get; set; }

    }
}
