using System;
using System.Collections.Generic;
using RR.Models;

namespace RR.Console
{
    public class InputOutput : IInputOutput
    {
        public string ReadString()
        {
            return System.Console.ReadLine();
        }

        public double ReadDouble()
        {
            return Convert.ToDouble(System.Console.ReadLine());
        }

        public void Output(string value)
        {
            System.Console.WriteLine(value);
        }

        public int ReadInteger()
        {
            return Convert.ToInt32(System.Console.ReadLine());
        }

        public void Output(IEnumerable<Restaurant> restaurants)
        {
            foreach (var i in restaurants)
            {
                System.Console.WriteLine(i);
            }
        }

        public void Output(IEnumerable<string> stringList)
        {
            foreach (var i in stringList)
            {
                System.Console.WriteLine(i);
            }
        }
    }
}
