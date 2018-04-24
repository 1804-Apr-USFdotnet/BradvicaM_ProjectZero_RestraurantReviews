using RR.Console.Controllers;

namespace RR.Console.Actions
{
    public class SearchAction : IApplicationAction
    {
        private readonly IRestaurantController _restaurantController;
        private readonly IInputOutput _inputOutput;

        public SearchAction(IRestaurantController restaurantController, IInputOutput inputOutput)
        {
            _restaurantController = restaurantController;
            _inputOutput = inputOutput;
        }

        public void Execute()
        {
            _restaurantController.InputSearchTerm().Render();

            var input = _inputOutput.ReadString();

            _restaurantController.SearchForEntity(input).Render();
        }
    }
}
