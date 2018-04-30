using System;
using System.Collections.Generic;
using Autofac;
using RR.Console.Actions;
using RR.DomainContracts;

namespace RR.Console
{
    public class Application : IApplication
    {
        private readonly IInputOutput _inputOutput;
        private Dictionary<int, IApplicationAction> _applicationActions;
        private const int HomeControllerIndex = 0;
        private const int AppliationClose = 12;
        private bool _runApplication = true;
        private readonly ILoggingService _logging;

        public Application(IInputOutput inputOutput, ILoggingService logging)
        {
            _inputOutput = inputOutput;
            _logging = logging;
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
                { 7, container.Resolve<SearchAction>() },
                { 8, container.Resolve<UpdateRestaurantAction>() },
                { 9, container.Resolve<DeleteRestaurantAction>() },
                { 10, container.Resolve<UpdateReviewAction>() },
                { 11, container.Resolve<DeleteReviewAction>() },
                { 12, container.Resolve<QuitAction>() }
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
                    _logging.Log(e);
                }
                catch (KeyNotFoundException e)
                {
                    _inputOutput.Output($"That Input is not viable! {e.Message}");
                    _logging.Log(e);
                }
                catch (Exception e)
                {
                    _logging.Log(e);
                }
            }
        }
    }
}
