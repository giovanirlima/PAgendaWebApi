using System;
using System.Collections.Generic;

namespace AgendaWebAPI.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public int Phone { get; set; }
        public List<Address> Address { get; set; }
    }
}
