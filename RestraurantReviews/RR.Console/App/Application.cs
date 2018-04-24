using System;
using System.Collections.Generic;
using Autofac;
using RR.Console.Actions;

namespace RR.Console
{
    public class Application : IApplication
    {
        private readonly IInputOutput _inputOutput;
        private readonly Dictionary<int, IApplicationAction> _applicationActions;

        private const int HomeControllerIndex = 0;
        private bool _runApplication = true;

        public Application(IInputOutput inputOutput, IContainer container)
        {
            _inputOutput = inputOutput;

            _applicationActions = new Dictionary<int, IApplicationAction>
            {
                { 0, container.Resolve<DefaultAction>() },
                { 1, container.Resolve<AddRestaurantAction>()},
                { 2, container.Resolve<ViewAllRestaurantsAction>() },
                { 3, container.Resolve<ReviewRestaurantAction>() },
                { 4, container.Resolve<TopThreeRatedRestaurantsAction>() },
                { 5, container.Resolve<ViewRestaurantDetailsAction>() },
                { 6, container.Resolve<AllReviewsOfRestaurantAction>() },
                { 7, container.Resolve<SearchAction>() }
            };
        }

        public void Run()
        {
            while (_runApplication)
            {
                _applicationActions[HomeControllerIndex].Execute();

                try
                {
                    var input = _inputOutput.ReadInteger();

                    if (input == 8)
                    {
                        _runApplication = false;
                    }

                    _applicationActions[input].Execute();
                }
                catch (FormatException e)
                {
                    System.Console.WriteLine($"Numbers Only! {e.Message}");
                }
                catch (KeyNotFoundException e)
                {
                    System.Console.WriteLine($"That Input is not viable! {e.Message}");
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
    }
}
