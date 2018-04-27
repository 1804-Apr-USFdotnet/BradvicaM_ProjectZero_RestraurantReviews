using RR.Console.Controllers;
using RR.ViewModels;

namespace RR.Console.Actions
{
    public class UpdateRestaurantAction : IApplicationAction
    {
        private readonly IRestaurantController _restaurantController;
        private readonly IInputOutput _inputOutput;

        public UpdateRestaurantAction(IRestaurantController restaurantController, IInputOutput inputOutput)
        {
            _restaurantController = restaurantController;
            _inputOutput = inputOutput;
        }

        public void Execute()
        {
            _restaurantController.AllRestaurants().Render();

            var restaurantToUpdate = _inputOutput.ReadString();

            _restaurantController.InputAddUpdateRestaurant().Render();

            var name = _inputOutput.ReadString();
            var street = _inputOutput.ReadString();
            var city = _inputOutput.ReadString();
            var state = _inputOutput.ReadString();
            var zipCode = _inputOutput.ReadInteger();
            var phone = _inputOutput.ReadString();
            var website = _inputOutput.ReadString();

            var viewModel = new UpdateRestaurantViewModel
            {
                City = city,
                Name = name,
                PhoneNumber = phone,
                State = state,
                Street = street,
                Website = website,
                ZipCode = zipCode
            };

            _restaurantController.UpdateRestaurant(restaurantToUpdate, viewModel).Render();
        }
    }
}
