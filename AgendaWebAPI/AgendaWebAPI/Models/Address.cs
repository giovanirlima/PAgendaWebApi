using Newtonsoft.Json;

namespace AgendaWebAPI.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int PersonId { get; set; }
        [JsonIgnore]
        public Person Person { get; set; }
    }
}
