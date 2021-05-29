using System;

namespace MvcDemo.Models
{
    public class ClientLog
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public string Action { get; set; }
        public string ActionBy { get; set; }

        public Client Client { get; set; } //Relation [One to one, One to many, Many to one, Many to many]

        public long ClientId { get; set; }
    }
}