using System;
using System.Collections.Generic;
using System.Linq;
using Library.BusinessInterfaces;
using Library.Models;

namespace Console
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
                                    "\n1 - Add A Restaurant\n2 - View All Restaurants\n3 - Review A Restaurant" +
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

        private void ViewAllRestaurants()
        {
            _inputOutput.Output("\nOrder By:\n1 - Name\n2 - State\n3 - Rating\n4 - City\n");

            int userInput = 0;

            try
            {
                userInput = _inputOutput.ReadInteger();
            }
            catch (Exception e)
            {
                _loggingService.Log(e);
            }

            var results = _restaurantService.AllRestaurants();
            IEnumerable<string> ordered = new List<string>();

            switch (userInput)
            {
                case 1:
                    results = results.OrderBy(x => x.Name).ToList();
                    ordered = results.Select(x => x.Name);
                    break;
                case 2:
                    results = results.OrderBy(x => x.State).ToList();
                    ordered = results.Select(x => x.Name + " " + x.State);
                    break;
                case 3:
                    results = results.OrderBy(x => x.AverageRating).ToList();
                    ordered = results.Select(x => x.Name + " " + x.AverageRating);
                    break;
                case 4:
                    results = results.OrderBy(x => x.City).ToList();
                    ordered = results.Select(x => x.Name + " " + x.City);
                    break;
                default:
                    _inputOutput.Output("\nNot Valid!\n");
                    Run();
                    break;
            }

            _inputOutput.Output("\nAll Restaurants:\n");
            _inputOutput.Output(ordered);
        }

        private void ReviewRestaurant()
        {
            var restaurntForReview = ChooseARestaurant();

            _inputOutput.Output("\nName please:\n");
            var name = _inputOutput.ReadString();

            _inputOutput.Output("\nRating please (number):\n");
            var rating = _inputOutput.ReadDouble();

            _inputOutput.Output("\nComments:\n");
            var comment = _inputOutput.ReadString();

            var review = new Review
            {
                Comment = comment,
                Id = Guid.NewGuid(),
                Restaurant = restaurntForReview,
                Rating = rating,
                ReviewerName = name
            };

            _reviewService.AddReview(review);
        }

        private void TopThreeRatedRestaurants()
        {
            var results = _restaurantService.TopThreeRestaurantByAverageReview();

            _inputOutput.Output("\nThe Top Three Rated Restaurants Are:\n");

            var viewModel = from x in results
                            select ($"Name: {x.Name} Rating: {x.AverageRating}");

            _inputOutput.Output(viewModel);
        }

        private void ViewRestaurantDetails()
        {
            var restaurantToShow = ChooseARestaurant();

            _inputOutput.Output(restaurantToShow);
        }

        private void AllReviewsOfARestaurant()
        {
            var restaurantForReviews = ChooseARestaurant();

            var reviews = _reviewService.AllReviews(restaurantForReviews);

            _inputOutput.Output(reviews);
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

        private void ViewRestaurantShortList()
        {
            var allretaurants = _restaurantService.AllRestaurants().ToList();

            var viewModel = new List<string>();

            for (var i = 0; i < allretaurants.Count; i++)
            {
                viewModel.Add(i + " - " + allretaurants[i].Name);
            }

            _inputOutput.Output(viewModel);
        }

        private Restaurant ChooseARestaurant()
        {
            ViewRestaurantShortList();

            _inputOutput.Output("\nChoose A Restaurant:");

            var restaurantIndex = _inputOutput.ReadInteger();

            var allRestaurnts = _restaurantService.AllRestaurants();

            return allRestaurnts[restaurantIndex];
        }
    }
}
