using System;

namespace HR.LeaveManagement.Application.Contracts.Persistence.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string name, object key) : base($"{name} ({key}) was not found.")
        {
            
        }
    }
}