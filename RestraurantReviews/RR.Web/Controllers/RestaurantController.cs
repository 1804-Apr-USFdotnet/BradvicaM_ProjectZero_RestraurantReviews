using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using RR.DomainContracts;
using RR.Models;
using RR.ViewModels;

namespace RR.Web.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly IRestaurantService _restaurantService;
        private readonly IMapper _mapper;

        public RestaurantController(IRestaurantService restaurantService, IMapper mapper)
        {
            _restaurantService = restaurantService;
            _mapper = mapper;
        }

        [Route("Restaurant/All")]
        [HttpGet]
        public ActionResult AllRestaurants()
        {
            var viewModel = _mapper.Map<IEnumerable<RestaurantViewModel>>(_restaurantService.AllRestaurants());

            return View(viewModel);
        }

        [Route("Restaurant/All")]
        [HttpPost]
        public ActionResult AllRestaurants(string searchBy)
        {
            var restaurants = _restaurantService.AllRestaurants(searchBy);

            var viewModel = _mapper.Map<IEnumerable<RestaurantViewModel>>(restaurants);

            return View(viewModel);
        }

        [Route("Restaurant/Add")]
        [HttpGet]
        public ActionResult AddRestaurant()
        {
            return View();
        }

        [Route("Restaurant/Add")]
        [HttpPost]
        public ActionResult AddRestaurant(AddRestaurantViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);

            var restaurant = _mapper.Map<Restaurant>(viewModel);

            _restaurantService.AddRestaurant(restaurant);

            return RedirectToAction("AddRestaurant");
        }
    }
}