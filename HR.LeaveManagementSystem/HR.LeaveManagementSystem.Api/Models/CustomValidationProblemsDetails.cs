using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagementSystem.Api.Models;

public class CustomValidationProblemsDetails : ProblemDetails
{
    public IDictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();
}