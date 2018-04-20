using System;
using System.Linq;
using RR.DomainContracts;
using RR.Models;

namespace RR.Console
{
    public class Application : IApplication
    {
        private readonly IRestaurantService _restaurantService;
        private readonly IReviewService _reviewService;
        private readonly ILoggingService _loggingService;
        private readonly IInputOutput _inputOutput;

        private bool _userIsDone;

        public Application(IRestaurantService restaurantService, IReviewService reviewService, ILoggingService loggingService, IInputOutput inputOutput)
        {
            _restaurantService = restaurantService;
            _reviewService = reviewService;
            _loggingService = loggingService;
            _inputOutput = inputOutput;
        }

        public void Run()
        {
            while (_userIsDone == false)
            {
                int userAction = 0;

                _inputOutput.Output($"\nWelcome to Restaurant Reviews, what would you like to do today?" +
                                    "\n1 - Add A Restaurant\n2 - View All Restaurants\n3 - Review A Restaurant"  +
                                    "\n4 - View Top Three Rated Restaurants\n5 - View Restaurant Details" +
                                    "\n6 - All Reviews Of A Restaurant\n7 - Search\n8 - Quit");

                try
                {
                    userAction = _inputOutput.ReadInteger();
                }
                catch (Exception e)
                {
                    _loggingService.Log(e);
                }
                
                switch (userAction)
                {
                    case 1:
                        AddRestaurant();
                        break;
                    case 2:
                        ViewAllRestaurants();
                        break;
                    case 3:
                        ReviewRestaurant();
                        break;
                    case 4:
                        TopThreeRatedRestaurants();
                        break;
                    case 5:
                        ViewRestaurantDetails();
                        break;
                    case 6:
                        AllReviewsOfARestaurant();
                        break;
                    case 7:
                        Search();
                        break;
                    case 8:
                        Quit();
                        break;
                    default:
                        _inputOutput.Output("\nThat is not an option!\n");
                        Run();
                        break;
                }
            }
        }

        private void AddRestaurant()
        {
            _inputOutput.Output("\nLets Add A Restaurant:\n");

            try
            {
                _inputOutput.Output("\nName of restaurant please:\n");
                var name = _inputOutput.ReadString();

                _inputOutput.Output("\nStree Address please:\n");
                var address = _inputOutput.ReadString();

                _inputOutput.Output("\nCity please:\n");
                var city = _inputOutput.ReadString();

                _inputOutput.Output("\nState please:\n");
                var state = _inputOutput.ReadString();

                _inputOutput.Output("\nZip Code please:\n");
                var zipCode = _inputOutput.ReadInteger();

                _inputOutput.Output("\nPhone Number please:\n");
                var phoneNumber = _inputOutput.ReadString();

                _inputOutput.Output("\nWebsite please:\n");
                var website = _inputOutput.ReadString();

                var restaurant = new Restaurant
                {
                    City = city,
                    Name = name,
                    PhoneNumber = phoneNumber,
                    State = state,
                    Street = address,
                    Website = website,
                    ZipCode = zipCode,
                    Id = Guid.NewGuid()
                };
                _restaurantService.AddRestaurant(restaurant);
            }
            catch (Exception e)
            {
                _loggingService.Log(e);
            }
        }

        private void ViewAllRestaurants()
        {
            _inputOutput.Output("\nAll Restaurants:\n");

            var results = _restaurantService.AllRestaurants();

            var restaurantList = results.Select(x => x.Name);

            _inputOutput.Output(restaurantList);
        }

        private void ReviewRestaurant()
        {

        }

        private void TopThreeRatedRestaurants()
        {
            var results = _restaurantService.TopThreeRestaurantByAverageReview();

            _inputOutput.Output("\nThe Top Three Rated Restaurants Are:\n");

            _inputOutput.Output(results);
        }

        private void ViewRestaurantDetails()
        {

        }

        private void AllReviewsOfARestaurant()
        {

        }

        private void Search()
        {
            _inputOutput.Output("\nPlease enter what keyword you are searching for:\n");

            var value = _inputOutput.ReadString();

            var results = _restaurantService.SearchByString(value);

            _inputOutput.Output(results);
        }

        private void Quit()
        {
            _userIsDone = true;
        }
    }
}
