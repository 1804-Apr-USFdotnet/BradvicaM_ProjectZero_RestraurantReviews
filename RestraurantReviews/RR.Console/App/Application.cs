using RR.Console.Controllers;
using RR.Console.Views;

namespace RR.Console
{
    public class Application : IApplication
    {
        private readonly IInputOutput _inputOutput;
        private readonly RestaurantController _restaurantController;
        private readonly ReviewController _reviewController;

        private bool _userIsDone;

        public Application(IInputOutput inputOutput, ReviewController reviewController, RestaurantController restaurantController)
        {
            _inputOutput = inputOutput;
            _reviewController = reviewController;
            _restaurantController = restaurantController;
        }

        public void Run()
        {
            while (_userIsDone == false)
            {
                Render(ViewEngine.Index());

                var input = _inputOutput.ReadInteger();
                
                switch (input)
                {
                    case 1:
                        //AddRestaurant();
                        break;
                    case 2:
                        //ViewAllRestaurants();
                        break;
                    case 3:
                        //ReviewRestaurant();
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

        /*
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

            var review = new AddReviewViewModel
            {
                Comment = comment,
                Restaurant = restaurntForReview,
                Rating = rating,
                ReviewerName = name
            };

            _reviewService.AddReview(_mapper.Map<Review>(review));
        }
        */

        private void TopThreeRatedRestaurants()
        {
            Render(_restaurantController.TopRatedRestaurants());
        }

        private void ViewRestaurantDetails()
        {
            Render(_restaurantController.AllRestaurants());

            Render(_restaurantController.RestaurantDetails(ReadInput()));
        }

        private void AllReviewsOfARestaurant()
        {
            Render(_restaurantController.InputRestaurantName());

            Render(_reviewController.RestaurantReviews(ReadInput()));
        }

        private void Search()
        {
            Render(_restaurantController.InputSearchTerm());

            Render(_restaurantController.SearchForEntity(ReadInput()));
        }

        private void Quit() => _userIsDone = true;
  
        private void Render(ActionResult view) => view.Render();

        private string ReadInput() => _inputOutput.ReadString();

        /*
        private void ViewRestaurantShortList()
        {
            var allretaurants = _restaurantService.AllRestaurants().ToList();

            var viewModel = _mapper.Map<IEnumerable<RestaurantNameViewModel>>(allretaurants);

            _inputOutput.Output(viewModel);
        }

        private Restaurant ChooseARestaurant()
        {
            ViewRestaurantShortList();

            _inputOutput.Output("\nChoose A Restaurant:");

            var restaurantName = _inputOutput.ReadString();

            return _restaurantService.SearchByName(restaurantName);
        }
        */

    }
}
