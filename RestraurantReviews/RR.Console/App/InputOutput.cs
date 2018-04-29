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
            var value = 0;

            try
            {
                value = Convert.ToInt32(System.Console.ReadLine());
            }
            catch (FormatException e)
            {
                System.Console.WriteLine($"Numbers Only! {e.Message}");
            }

            return value;
        }

        public double ReadDouble()
        {
            var value = 0.0;

            try
            {
                value = Convert.ToDouble(System.Console.ReadLine());
            }
            catch (FormatException e)
            {
                System.Console.WriteLine($"Numbers Only! {e.Message}");
            }

            return value;
        }

        public void Output(string value)
        {
            System.Console.WriteLine(value);
        }
    }
}
