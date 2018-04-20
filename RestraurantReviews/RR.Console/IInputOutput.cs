using System.Collections.Generic;
using RR.Models;

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
    }
}
