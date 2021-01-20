using System;

namespace MvcDemo.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string Address { get; set; }
        public string Product { get; set; }
        public DateTime RecDate { get; set; }
        public string ClientDate { get; set; }
    }
}
