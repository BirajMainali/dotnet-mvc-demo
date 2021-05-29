using System;
using System.Collections.Generic;

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

        public List<ClientLog> ClientLog { get; set; } = new List<ClientLog>();

        public long ClientLogId { get; set; }
    }
}