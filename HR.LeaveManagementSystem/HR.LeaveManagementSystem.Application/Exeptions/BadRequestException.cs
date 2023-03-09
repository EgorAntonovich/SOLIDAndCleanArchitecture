namespace HR.LeaveManagementSystem.Application.Exeptions;

public class BadRequestException : Exception
{
    public BadRequestException(string message) : base(message)
    {
        
    }
}