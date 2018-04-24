using System;
using System.Collections.Generic;
using Autofac;
using RR.Console.Actions;

namespace RR.Console
{
    public class Application : IApplication
    {
        private readonly IInputOutput _inputOutput;
        private Dictionary<int, IApplicationAction> _applicationActions;
        private const int HomeControllerIndex = 0;
        private const int AppliationClose = 8;
        private bool _runApplication = true;

        public Application(IInputOutput inputOutput)
        {
            _inputOutput = inputOutput; 
        }

        public void RegisterActions(IContainer container)
        {
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

                    if (input == AppliationClose)
                    {
                        _runApplication = false;
                    }

                    _applicationActions[input].Execute();
                }
                catch (FormatException e)
                {
                    _inputOutput.Output($"Numbers Only! {e.Message}");
                }
                catch (KeyNotFoundException e)
                {
                    _inputOutput.Output($"That Input is not viable! {e.Message}");
                }
            }
        }
    }
}
