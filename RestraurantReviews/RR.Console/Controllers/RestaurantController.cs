using System.Collections.Generic;
using AutoMapper;
using RR.Console.Views;
using RR.DomainContracts;
using RR.Models;
using RR.ViewModels;

namespace RR.Console.Controllers
{
    public class RestaurantController : IRestaurantController
    {
        private readonly IRestaurantService _restaurantService;
        private readonly IMapper _mapper;

        public RestaurantController(IRestaurantService restaurantService, IMapper mapper)
        {
            _restaurantService = restaurantService;
            _mapper = mapper;
        }

        public ActionResult InputAddUpdateRestaurant()
        {  
            return ViewEngine.InputAddUpdateRestaurant();
        }

        public ActionResult AddRestaurant(AddRestaurantViewModel viewModel)
        {
            var restaurant = _mapper.Map<Restaurant>(viewModel);

            _restaurantService.AddRestaurant(restaurant);

            return ViewEngine.AddRestaurant();
        }

        public ActionResult InputViewRestaurantsFilter()
        {
            return ViewEngine.InputViewRestaurantsFilter();
        }

        public ActionResult AllRestaurants(string orderBy)
        { 
            var ordered = _restaurantService.AllRestaurants(orderBy);

            var viewModel = _mapper.Map<IEnumerable<RestaurantNameViewModel>>(ordered);

            return ViewEngine.AllRestaurants(viewModel);
        }

        public ActionResult AllRestaurants()
        {
            var allRestaurants = _restaurantService.AllRestaurants();

            var viewModel = _mapper.Map<IEnumerable<RestaurantNameViewModel>>(allRestaurants);

            return ViewEngine.AllRestaurants(viewModel);
        }

        public ActionResult TopRatedRestaurants()
        {
            var results = _restaurantService.TopThreeRestaurantByAverageReview();

            var viewModel = _mapper.Map<IEnumerable<TopRatedRestaurantViewModel>>(results);

            return ViewEngine.TopRatedRestaurants(viewModel);
        }

        public ActionResult RestaurantDetails(string name)
        {
            var restaurant = _restaurantService.SearchByName(name);

            var viewModel = _mapper.Map<RestaurantViewModel>(restaurant);

            return ViewEngine.RestaurantDetails(viewModel);
        }

        public ActionResult SearchForEntity(string searchValue)
        {
            var results = _restaurantService.SearchAll(searchValue);

            var viewModel = _mapper.Map<IEnumerable<RestaurantViewModel>>(results);

            return ViewEngine.SearchForEntity(viewModel);
        }

        public ActionResult InputSearchTerm()
        {
            return ViewEngine.InputSearchTerm();
        }

        public ActionResult UpdateRestaurant(string restaurantName, UpdateRestaurantViewModel viewModel)
        {
            var restaurantToUpdate = _restaurantService.SearchByName(restaurantName);

            viewModel.Restaurant = restaurantToUpdate;

            var updatedRestaurant = _mapper.Map<Restaurant>(viewModel);

            _restaurantService.UpdateRestaurant(updatedRestaurant);

            return ViewEngine.UpdateRestaurant();
        }

        public ActionResult DeleteRestaurant(string restaurantName)
        {
            var restaurantToDelete = _restaurantService.SearchByName(restaurantName);

            _restaurantService.DeleteRestaurant(restaurantToDelete);

            return ViewEngine.DeleteRestaurant();
        }
    }
}
