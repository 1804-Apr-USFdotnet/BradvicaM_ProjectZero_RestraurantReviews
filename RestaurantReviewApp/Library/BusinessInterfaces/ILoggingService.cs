using System;

namespace Library.BusinessInterfaces
{
    public interface ILoggingService
    {
        void Log(Exception e);
    }
}
