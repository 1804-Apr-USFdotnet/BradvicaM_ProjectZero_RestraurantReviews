using System.Collections.Generic;
using Library.Models;

namespace Console
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
    }
}
