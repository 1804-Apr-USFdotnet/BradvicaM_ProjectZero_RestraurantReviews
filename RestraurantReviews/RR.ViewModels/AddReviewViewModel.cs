using RR.Models;

namespace RR.ViewModels
{
    public class AddReviewViewModel
    {
        public double Rating { get; set; }
        public string Comment { get; set; }
        public string ReviewerName { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}
