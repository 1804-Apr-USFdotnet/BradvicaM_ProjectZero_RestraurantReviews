using System;

namespace RR.Console
{
    public class InputOutput : IInputOutput
    {
        public string ReadString()
        {
            return System.Console.ReadLine();
        }

        public int ReadInteger()
        {
            return Convert.ToInt32(System.Console.ReadLine());
        }

        public double ReadDouble()
        {
            return Convert.ToDouble(System.Console.ReadLine());
        }

        public void Output(string value)
        {
            System.Console.WriteLine(value);
        }
    }
}
