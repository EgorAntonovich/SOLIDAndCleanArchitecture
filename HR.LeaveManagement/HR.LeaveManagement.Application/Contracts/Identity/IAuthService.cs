﻿using System.Threading.Tasks;
using HR.LeaveManagement.Application.Models.Identity;

namespace HR.LeaveManagement.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest authRequest);
        Task<RegistrationResponse> Registration(RegistrationRequest registrationRequest);
    }
}