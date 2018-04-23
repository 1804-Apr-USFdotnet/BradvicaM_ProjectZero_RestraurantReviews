﻿using System.Collections.Generic;
using RR.Models;
using RR.ViewModels;

namespace RR.Console
{
    public interface IInputOutput
    {
        string ReadString();
        double ReadDouble();
        void Output(string value);
        int ReadInteger();
        void Output(IEnumerable<Restaurant> restaurants);
        void Output(IEnumerable<string> stringList);
        void Output(Restaurant restaurant);
        void Output(IEnumerable<Review> reviews);

        void Output(IEnumerable<RestaurantNameViewModel> viewModels);
        void Output(IEnumerable<TopRatedRestaurantViewModel> viewModels);
    }
}
