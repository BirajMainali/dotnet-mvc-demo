using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MvcDemo.Models;

namespace MvcDemo.ViewModel
{
    public class ClientUpdateVm
    {
        [Required]
        [MaxLength(100)]
        [MinLength(5)]
        [DisplayName("Name of client")]
        public string ClientName { get; set; }

        public string Address { get; set; }
        public string Product { get; set; }
        public string ClientDate { get; set; }

        public Client Client;
    }
}