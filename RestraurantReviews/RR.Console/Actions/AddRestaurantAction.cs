using RR.Console.Controllers;
using RR.ViewModels;

namespace RR.Console.Actions
{
    public class AddRestaurantAction : IApplicationAction
    {
        private readonly RestaurantController _restaurantController;
        private readonly IInputOutput _inputOutput;

        public AddRestaurantAction(RestaurantController restaurantController, IInputOutput inputOutput)
        {
            _restaurantController = restaurantController;
            _inputOutput = inputOutput;
        }

        public void Execute()
        {
            _restaurantController.InputAddRestaurant().Render();

            var name = _inputOutput.ReadString();
            var street = _inputOutput.ReadString();
            var city = _inputOutput.ReadString();
            var state = _inputOutput.ReadString();
            var zipCode = _inputOutput.ReadInteger();
            var phone = _inputOutput.ReadString();
            var website = _inputOutput.ReadString();

            var viewModel = new AddRestaurantViewModel
            {
                City = city,
                Name = name,
                PhoneNumber = phone,
                State = state,
                Street = street,
                Website = website,
                ZipCode = zipCode
            };

            _restaurantController.AddRestaurant(viewModel).Render();
        }
    }
}
