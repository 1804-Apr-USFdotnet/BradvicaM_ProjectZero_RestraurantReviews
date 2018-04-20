using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using RR.DomainContracts;
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
        public ActionResult AllRestaurants()
        {
            var viewModel = _mapper.Map<IEnumerable<RestaurantViewModel>>(_restaurantService.AllRestaurants());

            return View(viewModel);
        }
    }
}