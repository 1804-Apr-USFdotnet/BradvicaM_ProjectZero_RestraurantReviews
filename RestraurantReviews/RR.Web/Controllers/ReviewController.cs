using System.Web.Mvc;
using AutoMapper;
using RR.DomainContracts;
using RR.ViewModels;

namespace RR.Web.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewService _reviewService;
        private readonly IRestaurantService _restaurantService;
        private readonly IMapper _mapper;

        public ReviewController(IReviewService reviewService, IRestaurantService restaurantService, IMapper mapper)
        {
            _reviewService = reviewService;
            _restaurantService = restaurantService;
            _mapper = mapper;
        }

        [Route("Review/Add")]
        [HttpPost]
        public ActionResult AddReview(RestaurantViewModel viewModel)
        {
            return View();
        }

        [Route("Review/Add")]
        [HttpPost]
        public ActionResult AddReview(AddReviewViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);

            return View();
        }
    }
}