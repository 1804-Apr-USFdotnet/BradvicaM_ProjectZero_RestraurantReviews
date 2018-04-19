using System;

namespace RR.DomainContracts
{
    public interface ILoggingService
    {
        void Log(Exception e);
    }
}
