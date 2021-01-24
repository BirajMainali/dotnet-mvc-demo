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

        public List<ClientLog> ClientLogs { get; set; } = new List<ClientLog>(); //One to many //One client has many client logs
    }
}