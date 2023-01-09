using System;

namespace HR.LeaveManagement.Application.Contracts.Persistence.Exceptions
{
    public class BadRequestException : ApplicationException
    {
        public BadRequestException(string message) : base(message)
        {
            
        }
    }
}