using System;

namespace RR.Models
{
    public class Review
    {
        public Guid Id { get; set; }
        public double Rating { get; set; }
        public string Comment { get; set; }

        public virtual Restaurant Restaurant { get; set; }

        public override string ToString()
        {
            return $"\nId: {Id}\nRating: {Rating}\nComment: {Comment}";
        }
    }
}
