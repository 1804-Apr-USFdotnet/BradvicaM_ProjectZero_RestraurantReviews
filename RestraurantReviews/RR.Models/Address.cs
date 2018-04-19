using System;

namespace RR.Models
{
    public class Address
    {
        public Guid Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }

        public override string ToString()
        {
            return $"{Street} {City} {State} {ZipCode}";
        }
    }
}
