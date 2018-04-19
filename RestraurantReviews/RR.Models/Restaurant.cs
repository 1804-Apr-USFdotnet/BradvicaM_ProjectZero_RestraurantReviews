using System;

namespace RR.Models
{
    public class Restaurant
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public string PhoneNumber { get; set; }
        public double Rating { get; set; }
        public string Website { get; set; }

        public override string ToString()
        {
            return $"\nId: {Id}\nName: {Name} \nAddress: {Address}\nPhoneNumber: {PhoneNumber}\nWebsite: {Website}\nRating: {Rating}";
        }
    }
}
