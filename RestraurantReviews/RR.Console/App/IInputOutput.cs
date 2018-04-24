namespace RR.Console
{
    public interface IInputOutput
    {
        string ReadString();
        int ReadInteger();
        double ReadDouble();
        void Output(string value);
    }
}
