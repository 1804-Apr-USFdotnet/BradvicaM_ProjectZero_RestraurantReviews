using RR.Models;

namespace RR.ViewModels
{
    public class UpdateReviewViewModel
    {
        public Review Review { get; set; }
        public double Rating { get; set; }
        public string Comment { get; set; }
        public string ReviewerName { get; set; }
        public int ReviewIdentification { get; set; }
    }
}
